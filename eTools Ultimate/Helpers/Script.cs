using eTools_Ultimate.Services;
using Scan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Helpers
{
    internal class Script : Scanner
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

		private bool LookupDefine(string str, out int value)
		{
			return DefinesService.Instance.Defines.TryGetValue(str, out value);
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
				if (StringsService.Instance.Strings.ContainsKey(Token))
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
								throw new Exception("Invalid token. Should be a number.");
						}
					}
				}
			}

			return Token;
        }
    }
}
