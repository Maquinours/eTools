using eTools_Ultimate.Exceptions;
using eTools_Ultimate.Services;
using Microsoft.Extensions.DependencyInjection;
using Scan;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Helpers
{
    public class Script : Scanner
    {
		static private string[] CommandTable = [
			" ",
			//" ", ARG,
			"int",
			"if",
			"else",
			"for",
			"do",
			"while",
			"break",
			"switch",
			"answer",
			"Select",
			"YesNo",
			"case",
			"default",
			"goto",
			"return",
			" ",
			"#define",
			"#include",
			"enum",
			//" "       , FINISHED,
			$"{(char)0}"         // , END
			];

		private bool LookUp(string str)
		{
			for (int i = 0; i < CommandTable.Length; ++i)
				if (CommandTable[i] == str)
					return true;
			return false;
        }

		private static bool LookupDefine(string str, out int value)
		{
			return App.Services.GetRequiredService<DefinesService>().Defines.TryGetValue(str, out value);
		}

		public static int GetDefineNum(string str)
		{
			if(LookupDefine(str, out int value))
				return value;
			return -1;
        }

        public override string GetToken(bool bComma = false)
        {
            base.GetToken(bComma);

			if(TokenType == TokenType.DELIMITER)
			{
				char firstChar = Token.ElementAtOrDefault(0);
				if (firstChar == '{' || firstChar == '}')
					TokenType = TokenType.BLOCK;
			}
			else if(TokenType == TokenType.TEMP)
			{
				if(LookUp(Token))
					TokenType = TokenType.KEYWORD;
				else
					TokenType = TokenType.IDENTIFIER;
            }

			if(TokenType == TokenType.IDENTIFIER)
			{
				if (App.Services.GetRequiredService<StringsService>().Strings.ContainsKey(Token))
					return Token;
				else
				{
					if(LookupDefine(Token, out int value))
					{
						TokenType = TokenType.NUMBER;
						Token = value.ToString();
                    }
					else
					{
						if (GettingType == GettingType.NUMBER)
						{
							char firstChar = Token.ElementAtOrDefault(0);
							if (firstChar != '\0' && firstChar != '=' && firstChar != '-' && firstChar != '+')
								throw new IncorrectlyFormattedFileException(base.FilePath); // Invalid token. Should be a number.
                        }
					}
				}
			}

			return Token;
        }

		public static string NumberToString(int number)
		{
			if (number == -1)
				return "=";
			return number.ToString(CultureInfo.InvariantCulture);
		}
        public static string NumberToString(int number, Dictionary<int, string> reverseDefines)
        {
			if (reverseDefines.TryGetValue(number, out string? result))
				return result;
            if (number == -1)
                return "=";
            return number.ToString(CultureInfo.InvariantCulture);
        }
        public static string Int64ToString(long number)
        {
            if (number == -1)
                return "=";
            return number.ToString(CultureInfo.InvariantCulture);
        }
        public static string FloatToString(float number)
        {
            if (number == -1f)
                return "=";
            return number.ToString(CultureInfo.InvariantCulture);
        }

		public static bool TryGetNumberFromString(string str, out int number)
		{
			if (App.Services.GetRequiredService<DefinesService>().Defines.TryGetValue(str, out int result))
            {
                number = result;
				return true;
            }
			if (str == "=")
			{
				number = -1;
				return true;
			}
			if(Int32.TryParse(str, out result))
			{
				number = result;
				return true;
			}

			number = default;
			return false;
		}
    }
}
