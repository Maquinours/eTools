//using eTools_Ultimate.Services;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace eTools_Ultimate.Models
//{
//    public class ExchangeDescription
//    {
//        private int _textId;

//        public ExchangeDescription(int textId)
//        {
//            this._textId = textId;
//        }
//    }
//    public class ExchangeSetResultMsg
//    {
//        private int _textId;

//        public ExchangeSetResultMsg(int textId)
//        {
//            this._textId = textId;
//        }
//    }

//    public class ExchangeSetCondition
//    {
//        private int _dwItemId;
//        private int _nItemNum;

//        public int DwItemId
//        {
//            get => this._dwItemId;
//        }
//        public int NItemNum
//        {
//            get => this._nItemNum;
//        }

//        public ExchangeSetCondition(int dwItemId, int nItemNum)
//        {
//            _dwItemId = dwItemId;
//            _nItemNum = nItemNum;
//        }
//    }

//    public class ExchangeSetRemove
//    {
//        private int _dwItemId;
//        private int _nItemNum;

//        public ExchangeSetRemove(int dwItemId, int nItemNum)
//        {
//            this._dwItemId = dwItemId;
//            this._nItemNum = nItemNum;
//        }
//    }

//    public class ExchangeSetConditionPoint
//    {
//        private int _nType;
//        private int _nPoint;

//        public ExchangeSetConditionPoint(int nType, int nPoint)
//        {
//            _nType = nType;
//            _nPoint = nPoint;
//        }
//    }

//    public class ExchangeSetRemovePoint
//    {
//        private int _nType;
//        private int _nPoint;
//        internal ExchangeSetRemovePoint(int nType, int nPoint)
//        {
//            _nType = nType;
//            _nPoint = nPoint;
//        }
//    }

//    public class ExchangeSetPay
//    {
//        private int _dwItemId;
//        private int _nItemNum;
//        private int _nPayProb;
//        private int _byFalg;

//        public ExchangeSetPay(int dwItemId, int nItemNum, int nPayProb, int byFalg)
//        {
//            this._dwItemId = dwItemId;
//            this._nItemNum = nItemNum;
//            this._nPayProb = nPayProb;
//            this._byFalg = byFalg;
//        }
//    }

//    public class ExchangeSet
//    {
//        private int _textId;
//        private List<ExchangeSetResultMsg> _resultMessages;
//        private List<ExchangeSetCondition> _conditions;
//        private List<ExchangeSetRemove> _removes;
//        private List<ExchangeSetConditionPoint> _conditionPoints;
//        private List<ExchangeSetRemovePoint> _removePoints;
//        private List<ExchangeSetPay> _pays;
        
//        public int TextId
//        {
//            get => this._textId;
//        }

//        public Text? Text
//        {
//            get => App.Services.GetRequiredService<TextsService>().Texts.FirstOrDefault(x => x.Prop.DwId == this.TextId);
//        }

//        public List<ExchangeSetCondition> Conditions
//        {
//            get => this._conditions;
//        }

//        public ExchangeSet(
//            int textId,
//            List<ExchangeSetResultMsg> resultMessages,
//            List<ExchangeSetCondition> conditions,
//            List<ExchangeSetRemove> removes,
//            List<ExchangeSetConditionPoint> conditionPoints,
//            List<ExchangeSetRemovePoint> removePoints,
//            List<ExchangeSetPay> pays)
//        {
//            this._textId = textId;
//            this._resultMessages = resultMessages;
//            this._conditions = conditions;
//            this._removes = removes;
//            this._conditionPoints = conditionPoints;
//            this._removePoints = removePoints;
//            this._pays = pays;
//        }
//    }

//    public class ExchangeSmeltSetResultMsg
//    {
//        private int _textId;
//        public ExchangeSmeltSetResultMsg(int textId)
//        {
//            this._textId = textId;
//        }
//    }

//    public class ExchangeSmeltSetCondition
//    {
//        private int _dwItemId;
//        private int _nItemQuantity;
//        private int _dwMinGeneralEnchant;
//        private int _dwMaxGeneralEnchant;
//        private int _dwMinAttributeEnchant;
//        private int _dwMaxAttributeEnchant;
//        private int _byAttributeKind;
//        private bool _bCheckScriptAttribute;

//        public ExchangeSmeltSetCondition(
//            int dwItemId,
//            int nItemQuantity,
//            int dwMinGeneralEnchant,
//            int dwMaxGeneralEnchant,
//            int dwMinAttributeEnchant,
//            int dwMaxAttributeEnchant,
//            int byAttributeKind,
//            bool bCheckScriptAttribute
//        )
//        {
//            this._dwItemId = dwItemId;
//            this._nItemQuantity = nItemQuantity;
//            this._dwMinGeneralEnchant = dwMinGeneralEnchant;
//            this._dwMaxGeneralEnchant = dwMaxGeneralEnchant;
//            this._dwMinAttributeEnchant = dwMinAttributeEnchant;
//            this._dwMaxAttributeEnchant = dwMaxAttributeEnchant;
//            this._byAttributeKind = byAttributeKind;
//            this._bCheckScriptAttribute = bCheckScriptAttribute;
//        }
//    }

//    public class ExchangeSmeltSetPay
//    {
//        private int _dwItemId;
//        private int _nItemQuantity;
//        private int _dwPaymentProb;
//        private int _byItemFlag;
//        private int _dwMinGeneralEnchant;
//        private int _dwMaxGeneralEnchant;
//        private int _dwMinAttributeEnchant;
//        private int _dwMaxAttributeEnchant;
//        private int _byAttributeKind;
//        private bool _bCheckAttribute;

//        public ExchangeSmeltSetPay(
//            int dwItemId,
//            int nItemQuantity,
//            int dwPaymentProb,
//            int byItemFlag,
//            int dwMinGeneralEnchant,
//            int dwMaxGeneralEnchant,
//            int dwMinAttributeEnchant,
//            int dwMaxAttributeEnchant,
//            int byAttributeKind,
//            bool bCheckAttribute)
//        {
//            _dwItemId = dwItemId;
//            _nItemQuantity = nItemQuantity;
//            _dwPaymentProb = dwPaymentProb;
//            _byItemFlag = byItemFlag;
//            _dwMinGeneralEnchant = dwMinGeneralEnchant;
//            _dwMaxGeneralEnchant = dwMaxGeneralEnchant;
//            _dwMinAttributeEnchant = dwMinAttributeEnchant;
//            _dwMaxAttributeEnchant = dwMaxAttributeEnchant;
//            _byAttributeKind = byAttributeKind;
//            _bCheckAttribute = bCheckAttribute;
//        }
//    }

//    public class ExchangeSmeltSet
//    {
//        private List<ExchangeSmeltSetResultMsg> _resultMessages;
//        private List<ExchangeSmeltSetCondition> _conditions;
//        private List<ExchangeSmeltSetPay> _pays;

//        internal ExchangeSmeltSet(
//            List<ExchangeSmeltSetResultMsg> resultMessages,
//            List<ExchangeSmeltSetCondition> conditions,
//            List<ExchangeSmeltSetPay> pays)
//        {
//            this._resultMessages = resultMessages;
//            this._conditions = conditions;
//            this._pays = pays;
//        }
//    }

//    public class ExchangeEnchantMoveSetResultMsg
//    {
//        private int _textId;
//        internal ExchangeEnchantMoveSetResultMsg(int textId)
//        {
//            this._textId = textId;
//        }
//    }

//    public class ExchangeEnchantMoveSetCondition
//    {
//        private int _dwItemId;

//        internal ExchangeEnchantMoveSetCondition(int dwItemId)
//        {
//            this._dwItemId = dwItemId;
//        }
//    }

//    public class ExchangeEnchantMoveSetPay
//    {
//        private int _dwItemId;
//        private int _byItemFlag;

//        internal ExchangeEnchantMoveSetPay(int dwItemId, int byItemFlag)
//        {
//            this._dwItemId = dwItemId;
//            this._byItemFlag = byItemFlag;
//        }
//    }

//    public class ExchangeEnchantMoveSet
//    {
//        private List<ExchangeEnchantMoveSetResultMsg> _resultMessages;
//        private List<ExchangeEnchantMoveSetCondition> _conditions;
//        private List<ExchangeEnchantMoveSetPay> _pays;

//        internal ExchangeEnchantMoveSet(
//            List<ExchangeEnchantMoveSetResultMsg> resultMessages,
//            List<ExchangeEnchantMoveSetCondition> conditions,
//            List<ExchangeEnchantMoveSetPay> pays)
//        {
//            this._resultMessages = resultMessages;
//            this._conditions = conditions;
//            this._pays = pays;
//        }
//    }

//    public class Exchange : IDisposable
//    {
//        private int _mmiId;
//        private List<ExchangeDescription> _descriptions;
//        private List<ExchangeSet> _sets;
//        private List<ExchangeSmeltSet> _smeltSets;
//        private List<ExchangeEnchantMoveSet> _enchantMoveSets;

//        public int MmiId
//        {
//            get => this._mmiId;
//            set
//            {
//                if(this.MmiId != value)
//                {
//                    this._mmiId = value;
//                }
//            }
//        }

//        public string MmiIdentifier => App.Services.GetRequiredService<DefinesService>().ReversedMenuItemDefines.TryGetValue(this.MmiId, out string? identifier) ? identifier : this.MmiId.ToString();

//        public List<ExchangeSet> Sets
//        {
//            get => this._sets;
//        }

//        public Exchange(int mmiId, List<ExchangeDescription> descriptions, List<ExchangeSet> sets, List<ExchangeSmeltSet> smeltSets, List<ExchangeEnchantMoveSet> enchantMoveSets)
//        {
//            this._mmiId = mmiId;
//            this._descriptions = descriptions;
//            this._sets = sets;
//            this._smeltSets = smeltSets;
//            this._enchantMoveSets = enchantMoveSets;
//        }
//        public void Dispose() { }
//    }
//}
