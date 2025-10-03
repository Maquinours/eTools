using Scan;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Common
{
    internal sealed partial class Project
    {
        #region Properties
        /// <summary>
        /// List of strings (IDS => value)
        /// </summary>
        public readonly ObservableDictionary<string, string> strings;
        #endregion

        #region Methods
        private void LoadStrings(string filePath)
        {
            this.strings.Clear();

            Scanner scanner = new Scanner();
            scanner.Load(filePath);

            while (true)
            {
                string index = scanner.GetToken();

                if (scanner.EndOfStream) break;

                /* The index must start with "IDS_" to be a valid string. If the file find token starting with
                 * something different, then the file is incorrectly formatted.
                 * */
                if (!index.StartsWith("IDS_"))
                    throw new IncorrectlyFormattedFileException(filePath);

                string value = scanner.GetLine();
                this.strings.Add(index, value);
            }
            scanner.Close();
        }

        private void SaveStrings(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false, new UnicodeEncoding()))
            {
                foreach (KeyValuePair<string, string> str in strings)
                    writer.Write($"{str.Key}\t{str.Value}\r\n");
            }
        }

        public void GenerateNewString(string stringIdentifier)
        {
            if (!this.strings.ContainsKey(stringIdentifier))
                this.strings.Add(stringIdentifier, "");
        }

        /// <summary>
        /// Get the next string identifier available.
        /// </summary>
        /// <returns>The next available string</returns>
        public string GetNextStringIdentifier()
        {
            string stringStarter = "IDS_"
#if __MOVERS
                + "PROPMOVER_TXT_"
#elif __ITEMS
                + "PROPITEM_TXT_"
#endif
                ;
            for (int i = 0; true; i++)
            {
                string identifier = stringStarter + i.ToString("D6");
                if (!this.strings.ContainsKey(identifier))
                    return identifier;
            }
        }

        public string GetString(string ids)
        {
            return strings[ids];
        }

        public void ChangeStringValue(string ids, string newValue)
        {
            strings[ids] = newValue;
        }
        #endregion
    }
}
