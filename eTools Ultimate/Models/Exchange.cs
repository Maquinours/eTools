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
    internal class Exchange : IDisposable
    {
        private string _mmiId;
        private List<ExchangeDescription> _descriptions;
        private List<ExchangeSet> _sets;

        public string MmiId
        {
            get => this._mmiId;
        }

        public Exchange(string mmiId, List<ExchangeDescription> descriptions, List<ExchangeSet> sets)
        {
            this._mmiId = mmiId;
            this._descriptions = descriptions;
            this._sets = sets;
        }
        public void Dispose() { }
    }
}
