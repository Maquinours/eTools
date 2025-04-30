using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Models
{
    internal class ExchangeDescription
    {
        private string _textId;

        internal ExchangeDescription(string textId)
        {
            this._textId = textId;
        }
    }
    internal class ExchangeSetResultMsg
    {
        private string _textId;

        internal ExchangeSetResultMsg(string textId)
        {
            this._textId = textId;
        }
    }

    internal class ExchangeSetCondition
    {
        private string _dwItemId;
        private int _nItemNum;

        public string DwItemId
        {
            get => this.DwItemId;
        }
        public int NItemNum
        {
            get => this.NItemNum;
        }

        internal ExchangeSetCondition(string dwItemId, int nItemNum)
        {
            _dwItemId = dwItemId;
            _nItemNum = nItemNum;
        }
    }

    internal class ExchangeSetRemove
    {
        private string _dwItemId;
        private int _nItemNum;

        internal ExchangeSetRemove(string dwItemId, int nItemNum)
        {
            this._dwItemId = dwItemId;
            this._nItemNum = nItemNum;
        }
    }

    internal class ExchangeSetConditionPoint
    {
        private string _nType;
        private int _nPoint;

        internal ExchangeSetConditionPoint(string nType, int nPoint)
        {
            _nType = nType;
            _nPoint = nPoint;
        }
    }

    internal class ExchangeSetRemovePoint
    {
        private string _nType;
        private int _nPoint;
        internal ExchangeSetRemovePoint(string nType, int nPoint)
        {
            _nType = nType;
            _nPoint = nPoint;
        }
    }

    internal class ExchangeSetPay
    {
        private string _dwItemId;
        private int _nItemNum;
        private int _nPayProb;
        private int _byFalg;

        internal ExchangeSetPay(string dwItemId, int nItemNum, int nPayProb, int byFalg)
        {
            this._dwItemId = dwItemId;
            this._nItemNum = nItemNum;
            this._nPayProb = nPayProb;
            this._byFalg = byFalg;
        }
    }

    internal class ExchangeSet
    {
        private List<ExchangeSetResultMsg> _resultMessages;
        private List<ExchangeSetCondition> _conditions;
        private List<ExchangeSetRemove> _removes;
        private List<ExchangeSetConditionPoint> _conditionPoints;
        private List<ExchangeSetRemovePoint> _removePoints;
        private List<ExchangeSetPay> _pays;

        internal ExchangeSet(
            List<ExchangeSetResultMsg> resultMessages,
            List<ExchangeSetCondition> conditions,
            List<ExchangeSetRemove> removes,
            List<ExchangeSetConditionPoint> conditionPoints,
            List<ExchangeSetRemovePoint> removePoints,
            List<ExchangeSetPay> pays)
        {
            this._resultMessages = resultMessages;
            this._conditions = conditions;
            this._removes = removes;
            this._conditionPoints = conditionPoints;
            this._removePoints = removePoints;
            this._pays = pays;
        }
    }

    internal class ExchangeSmeltSetResultMsg
    {
        private string _textId;
        internal ExchangeSmeltSetResultMsg(string textId)
        {
            this._textId = textId;
        }
    }

    internal class ExchangeSmeltSetCondition
    {
        private string _dwItemId;
        private int _nItemQuantity;
        private int _dwMinGeneralEnchant;
        private int _dwMaxGeneralEnchant;
        private int _dwMinAttributeEnchant;
        private int _dwMaxAttributeEnchant;
        private int _byAttributeKind;
        private bool _bCheckScriptAttribute;

        internal ExchangeSmeltSetCondition(
            string dwItemId,
            int nItemQuantity,
            int dwMinGeneralEnchant,
            int dwMaxGeneralEnchant,
            int dwMinAttributeEnchant,
            int dwMaxAttributeEnchant,
            int byAttributeKind,
            bool bCheckScriptAttribute
        )
        {
            this._dwItemId = dwItemId;
            this._nItemQuantity = nItemQuantity;
            this._dwMinGeneralEnchant = dwMinGeneralEnchant;
            this._dwMaxGeneralEnchant = dwMaxGeneralEnchant;
            this._dwMinAttributeEnchant = dwMinAttributeEnchant;
            this._dwMaxAttributeEnchant = dwMaxAttributeEnchant;
            this._byAttributeKind = byAttributeKind;
            this._bCheckScriptAttribute = bCheckScriptAttribute;
        }
    }

    internal class ExchangeSmeltSetPay
    {
        private string _dwItemId;
        private int _nItemQuantity;
        private int _dwPaymentProb;
        private int _byItemFlag;
        private int _dwMinGeneralEnchant;
        private int _dwMaxGeneralEnchant;
        private int _dwMinAttributeEnchant;
        private int _dwMaxAttributeEnchant;
        private int _byAttributeKind;
        private bool _bCheckAttribute;

        internal ExchangeSmeltSetPay(
            string dwItemId,
            int nItemQuantity,
            int dwPaymentProb,
            int byItemFlag,
            int dwMinGeneralEnchant,
            int dwMaxGeneralEnchant,
            int dwMinAttributeEnchant,
            int dwMaxAttributeEnchant,
            int byAttributeKind,
            bool bCheckAttribute)
        {
            _dwItemId = dwItemId;
            _nItemQuantity = nItemQuantity;
            _dwPaymentProb = dwPaymentProb;
            _byItemFlag = byItemFlag;
            _dwMinGeneralEnchant = dwMinGeneralEnchant;
            _dwMaxGeneralEnchant = dwMaxGeneralEnchant;
            _dwMinAttributeEnchant = dwMinAttributeEnchant;
            _dwMaxAttributeEnchant = dwMaxAttributeEnchant;
            _byAttributeKind = byAttributeKind;
            _bCheckAttribute = bCheckAttribute;
        }
    }

    internal class ExchangeSmeltSet
    {
        private List<ExchangeSmeltSetResultMsg> _resultMessages;
        private List<ExchangeSmeltSetCondition> _conditions;
        private List<ExchangeSmeltSetPay> _pays;

        internal ExchangeSmeltSet(
            List<ExchangeSmeltSetResultMsg> resultMessages,
            List<ExchangeSmeltSetCondition> conditions,
            List<ExchangeSmeltSetPay> pays)
        {
            this._resultMessages = resultMessages;
            this._conditions = conditions;
            this._pays = pays;
        }
    }

    internal class ExchangeEnchantMoveSetResultMsg
    {
        private string _textId;
        internal ExchangeEnchantMoveSetResultMsg(string textId)
        {
            this._textId = textId;
        }
    }

    internal class ExchangeEnchantMoveSetCondition
    {
        private string _dwItemId;

        internal ExchangeEnchantMoveSetCondition(string dwItemId)
        {
            this._dwItemId = dwItemId;
        }
    }

    internal class ExchangeEnchantMoveSetPay
    {
        private string _dwItemId;
        private int _byItemFlag;

        internal ExchangeEnchantMoveSetPay(string dwItemId, int byItemFlag)
        {
            this._dwItemId = dwItemId;
            this._byItemFlag = byItemFlag;
        }
    }

    internal class ExchangeEnchantMoveSet
    {
        private List<ExchangeEnchantMoveSetResultMsg> _resultMessages;
        private List<ExchangeEnchantMoveSetCondition> _conditions;
        private List<ExchangeEnchantMoveSetPay> _pays;

        internal ExchangeEnchantMoveSet(
            List<ExchangeEnchantMoveSetResultMsg> resultMessages,
            List<ExchangeEnchantMoveSetCondition> conditions,
            List<ExchangeEnchantMoveSetPay> pays)
        {
            this._resultMessages = resultMessages;
            this._conditions = conditions;
            this._pays = pays;
        }
    }

    internal class Exchange : IDisposable
    {
        private string _mmiId;
        private List<ExchangeDescription> _descriptions;
        private List<ExchangeSet> _sets;
        private List<ExchangeSmeltSet> _smeltSets;
        private List<ExchangeEnchantMoveSet> _enchantMoveSets;

        public string MmiId
        {
            get => this._mmiId;
        }

        public Exchange(string mmiId, List<ExchangeDescription> descriptions, List<ExchangeSet> sets, List<ExchangeSmeltSet> smeltSets, List<ExchangeEnchantMoveSet> enchantMoveSets)
        {
            this._mmiId = mmiId;
            this._descriptions = descriptions;
            this._sets = sets;
            this._smeltSets = smeltSets;
            this._enchantMoveSets = enchantMoveSets;
        }
        public void Dispose() { }
    }
}
