using eTools_Ultimate.Models;
using Scan;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTools_Ultimate.Exceptions;
using System.Globalization;

namespace eTools_Ultimate.Services
{
    internal class ExchangesService
    {
        private static readonly Lazy<ExchangesService> _instance = new(() => new());
        public static ExchangesService Instance => _instance.Value;

        private readonly ObservableCollection<Exchange> _exchanges = [];
        public ObservableCollection<Exchange> Exchanges => this._exchanges;

        private void ClearExchanges()
        {
            foreach (Exchange exchange in this.Exchanges)
                exchange.Dispose();
            this.Exchanges.Clear();
        }

        public void Load()
        {
            this.ClearExchanges();

            Settings settings = Settings.Instance;
            StringsService stringsService = StringsService.Instance;
            DefinesService definesService = DefinesService.Instance;

            using (Scanner scanner = new Scanner())
            {
                string filePath = settings.ExchangesConfigFilePath ?? settings.DefaultExchangesConfigFilePath;
                scanner.Load(filePath);
                while (true)
                {
                    string mmiId = scanner.GetToken();

                    if (scanner.EndOfStream) break;

                    List<ExchangeDescription> descriptions = new();
                    List<ExchangeSet> sets = new();
                    List<ExchangeSmeltSet> smeltSets = new();
                    List<ExchangeEnchantMoveSet> enchantMoveSets = new();

                    scanner.GetToken(); // {

                    while (true)
                    {
                        string token = scanner.GetToken();

                        if (token == "}") break;
                        if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                        switch(token)
                        {
                            case "DESCRIPTION":
                                {
                                    scanner.GetToken(); // {
                                    while(true)
                                    {
                                        string textId = scanner.GetToken();

                                        if (textId == "}") break;
                                        if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                                        ExchangeDescription description = new(textId);
                                        descriptions.Add(description);
                                    }
                                    break;
                                }
                            case "SET":
                                {
                                    string textId = scanner.GetToken();
                                    List<ExchangeSetResultMsg> resultMessages = new();
                                    List<ExchangeSetCondition> conditions = new();
                                    List<ExchangeSetRemove> removes = new();
                                    List<ExchangeSetConditionPoint> conditionPoints = new();
                                    List<ExchangeSetRemovePoint> removePoints = new();
                                    List<ExchangeSetPay> pays = new();

                                    scanner.GetToken(); // {
                                    while(true)
                                    {
                                        string token2 = scanner.GetToken();

                                        if (token2 == "}") break;
                                        if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                                        switch(token2)
                                        {
                                            case "RESULTMSG":
                                                {
                                                    scanner.GetToken(); // {
                                                    while(true)
                                                    {
                                                        string textId2 = scanner.GetToken();

                                                        if (textId2 == "}") break;
                                                        if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                                                        ExchangeSetResultMsg resultMsg = new(textId2);
                                                        resultMessages.Add(resultMsg);
                                                    }
                                                    break;
                                                }
                                            case "CONDITION":
                                                {
                                                    scanner.GetToken(); // {
                                                    while(true)
                                                    {
                                                        string dwItemId = scanner.GetToken();

                                                        if (dwItemId == "}") break;
                                                        if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);
                                                        
                                                        // Not sure we should keep that
                                                        if (dwItemId == "PENYA")
                                                            dwItemId = "II_GOLD_SEED1";

                                                        int nItemNum = scanner.GetNumber();

                                                        ExchangeSetCondition condition = new(dwItemId, nItemNum);
                                                        conditions.Add(condition);
                                                        if (settings.ResourcesVersion >= 19) // We can handle it in the getters/setters. Not sure to handle it here
                                                            removes.Add(new ExchangeSetRemove(dwItemId, nItemNum));
                                                    }
                                                    break;
                                                }
                                            case "REMOVE":
                                                {
                                                    scanner.GetToken(); // {
                                                    while(true)
                                                    {
                                                        string dwItemId = scanner.GetToken();

                                                        if (dwItemId == "}") break;
                                                        if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                                                        // Not sure we should keep that
                                                        if (dwItemId == "PENYA")
                                                            dwItemId = "II_GOLD_SEED1";

                                                        int nItemNum = scanner.GetNumber();

                                                        if (settings.ResourcesVersion < 19) // We can handle it in the getters/setters. Not sure to handle it here
                                                        {
                                                            ExchangeSetRemove remove = new(dwItemId, nItemNum);
                                                            removes.Add(remove);
                                                        }
                                                    }
                                                    break;
                                                }
                                            case "CONDITION_POINT":
                                                {
                                                    if (settings.ResourcesVersion < 15) break;

                                                    scanner.GetToken(); // {
                                                    while(true)
                                                    {
                                                        string nType = scanner.GetToken();

                                                        if (nType == "}") break;
                                                        if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                                                        int nPoint = scanner.GetNumber();

                                                        if (!definesService.Defines.ContainsKey(nType) || definesService.Defines[nType] <= 0) // nType should be > 0
                                                            throw new IncorrectlyFormattedFileException(filePath); // CExchange::Load_Script() - Invalid CONDITION_POINT Type

                                                        ExchangeSetConditionPoint conditionPoint = new(nType, nPoint);
                                                        conditionPoints.Add(conditionPoint);
                                                    }
                                                    break;
                                                }
                                            case "REMOVE_POINT":
                                                {
                                                    if (settings.ResourcesVersion < 15) break;

                                                    scanner.GetToken(); // {
                                                    while (true)
                                                    {
                                                        string nType = scanner.GetToken();

                                                        if (nType == "}") break;
                                                        if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                                                        int nPoint = scanner.GetNumber();

                                                        if (!definesService.Defines.ContainsKey(nType) || definesService.Defines[nType] <= 0) // nType should be > 0
                                                            throw new IncorrectlyFormattedFileException(filePath); // CExchange::Load_Script() - Invalid REMOVE_POINT Type

                                                        ExchangeSetRemovePoint removePoint = new(nType, nPoint);
                                                        removePoints.Add(removePoint);
                                                    }
                                                    break;
                                                }
                                            case "PAY":
                                                {
                                                    int nPayNum = scanner.GetNumber();

                                                    scanner.GetToken(); // {
                                                    bool useCurrentToken = false;
                                                    while(true)
                                                    {
                                                        string dwItemId = useCurrentToken ? scanner.Token : scanner.GetToken();

                                                        if (dwItemId == "}") break;
                                                        if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                                                        int nItemNum = scanner.GetNumber();
                                                        int nPayProb = scanner.GetNumber();

                                                        //scanner.SetMark();
                                                        string token3 = scanner.GetToken();
                                                        //scanner.GoMark();
                                                        if (Int32.TryParse(token3, new CultureInfo("en-EN"), out int byFalg))
                                                            useCurrentToken = false;
                                                        else
                                                        {
                                                            useCurrentToken = true;
                                                            byFalg = 0;
                                                        }

                                                        ExchangeSetPay pay = new(dwItemId, nItemNum, nPayProb, byFalg);
                                                        pays.Add(pay);

                                                        // There are more conditions but not sure it's useful to implement
                                                    }
                                                    break;
                                                }
                                        }
                                    }

                                    ExchangeSet set = new(resultMessages, conditions, removes, conditionPoints, removePoints, pays);
                                    sets.Add(set);
                                    break;
                                }
                            case "SET_SMELT":
                                {
                                    string textId = scanner.GetToken();
                                    List<ExchangeSmeltSetResultMsg> resultMessages = new();
                                    List<ExchangeSmeltSetCondition> conditions = new();
                                    List<ExchangeSmeltSetPay> pays = new();

                                    scanner.GetToken(); // {
                                    while (true)
                                    {
                                        string token2 = scanner.GetToken();

                                        if (token2 == "}") break;
                                        if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                                        switch (token2)
                                        {
                                            case "RESULTMSG":
                                                {
                                                    scanner.GetToken(); // {
                                                    while (true)
                                                    {
                                                        string textId2 = scanner.GetToken();

                                                        if (textId2 == "}") break;
                                                        if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                                                        ExchangeSmeltSetResultMsg resultMsg = new(textId2);
                                                        resultMessages.Add(resultMsg);
                                                    }

                                                    break;
                                                }
                                            case "CONDITION":
                                                {
                                                    scanner.GetToken(); // {
                                                    while(true)
                                                    {
                                                        string dwItemId = scanner.GetToken();

                                                        if (dwItemId == "}") break;
                                                        if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                                                        // Not sure we should keep that
                                                        if (dwItemId == "PENYA")
                                                            dwItemId = "II_GOLD_SEED1";

                                                        int nItemQuantity = scanner.GetNumber();
                                                        int dwMinGeneralEnchant = scanner.GetNumber();
                                                        int dwMaxGeneralEnchant = scanner.GetNumber();

                                                        int dwMinAttributeEnchant = scanner.GetNumber();
                                                        int dwMaxAttributeEnchant = scanner.GetNumber();

                                                        int byAttributeKind = scanner.GetNumber();
                                                        bool bCheckScriptAttribute = scanner.GetNumber() != 0;

                                                        ExchangeSmeltSetCondition condition = new(dwItemId, nItemQuantity, dwMinGeneralEnchant, dwMaxGeneralEnchant, dwMinAttributeEnchant, dwMaxAttributeEnchant, byAttributeKind, bCheckScriptAttribute);
                                                        conditions.Add(condition);
                                                    }

                                                    break;
                                                }
                                            case "REMOVE":
                                                {
                                                    scanner.GetToken(); // {
                                                    do
                                                    {
                                                        scanner.GetToken();
                                                    } while (scanner.Token != "}");

                                                    break;
                                                }
                                            case "PAY":
                                                {
                                                    int nPayNum = scanner.GetNumber();
                                                    scanner.GetToken(); // {
                                                    while(true)
                                                    {
                                                        string dwItemId = scanner.GetToken();

                                                        if (dwItemId == "}") break;
                                                        if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                                                        int nItemQuantity = scanner.GetNumber();
                                                        int dwPaymentProb = scanner.GetNumber();
                                                        int byItemFlag = scanner.GetNumber();

                                                        int dwMinGeneralEnchant = scanner.GetNumber();
                                                        int dwMaxGeneralEnchant = scanner.GetNumber();

                                                        int dwMinAttributeEnchant = scanner.GetNumber();
                                                        int dwMaxAttributeEnchant = scanner.GetNumber();

                                                        int byAttributeKind = scanner.GetNumber();
                                                        bool bCheckAttribute = scanner.GetNumber() != 0;

                                                        ExchangeSmeltSetPay pay = new(dwItemId, nItemQuantity, dwPaymentProb, byItemFlag, dwMinGeneralEnchant, dwMaxGeneralEnchant, dwMinAttributeEnchant, dwMaxAttributeEnchant, byAttributeKind, bCheckAttribute);
                                                        pays.Add(pay);
                                                    }

                                                    break;
                                                }
                                        }
                                    }
                                    ExchangeSmeltSet smeltSet = new(resultMessages, conditions, pays);
                                    smeltSets.Add(smeltSet);

                                    break;
                                }

                            case "SET_ENCHANT_MOVE":
                                {
                                    string textId = scanner.GetToken();
                                    List<ExchangeEnchantMoveSetResultMsg> resultMessages = new();
                                    List<ExchangeEnchantMoveSetCondition> conditions = new();
                                    List<ExchangeEnchantMoveSetPay> pays = new();

                                    scanner.GetToken(); // {
                                    while (true)
                                    {
                                        string token2 = scanner.GetToken();

                                        if (token2 == "}") break;
                                        if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                                        switch (token2)
                                        {
                                            case "RESULTMSG":
                                                {
                                                    scanner.GetToken(); // {
                                                    while (true)
                                                    {
                                                        string textId2 = scanner.GetToken();

                                                        if (textId2 == "}") break;
                                                        if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                                                        ExchangeEnchantMoveSetResultMsg resultMsg = new(textId2);
                                                        resultMessages.Add(resultMsg);
                                                    }

                                                    break;
                                                }
                                            case "CONDITION":
                                                {
                                                    scanner.GetToken(); // {
                                                    while (true)
                                                    {
                                                        string dwItemId = scanner.GetToken();

                                                        if (dwItemId == "}") break;
                                                        if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                                                        // Not sure we should keep that
                                                        if (dwItemId == "PENYA")
                                                            dwItemId = "II_GOLD_SEED1";

                                                        ExchangeEnchantMoveSetCondition condition = new(dwItemId);
                                                        conditions.Add(condition);
                                                    }

                                                    break;
                                                }
                                            case "REMOVE":
                                                {
                                                    scanner.GetToken(); // {
                                                    do
                                                    {
                                                        scanner.GetToken();
                                                    } while (scanner.Token != "}");

                                                    break;
                                                }
                                            case "PAY":
                                                {
                                                    int nPayNum = scanner.GetNumber();
                                                    scanner.GetToken(); // {

                                                    bool useCurrentToken = false;
                                                    while (true)
                                                    {
                                                        string dwItemId = useCurrentToken ? scanner.Token : scanner.GetToken();

                                                        if (dwItemId == "}") break;
                                                        if (scanner.EndOfStream) throw new IncorrectlyFormattedFileException(filePath);

                                                        string token3 = scanner.GetToken();
                                                        if (Int32.TryParse(token3, new CultureInfo("en-EN"), out int byItemFlag))
                                                            useCurrentToken = false;
                                                        else
                                                        {
                                                            useCurrentToken = true;
                                                            byItemFlag = 0;
                                                        }

                                                        ExchangeEnchantMoveSetPay pay = new(dwItemId, byItemFlag);
                                                        pays.Add(pay);
                                                    }

                                                    break;
                                                }
                                        }
                                    }

                                    ExchangeEnchantMoveSet enchantMoveSet = new(resultMessages, conditions, pays);
                                    enchantMoveSets.Add(enchantMoveSet);

                                    break;
                                }
                        }
                    }
                    Exchange exchange = new(mmiId, descriptions, sets, smeltSets, enchantMoveSets);
                    this.Exchanges.Add(exchange);
                }
            }
        }
    }
}
