using eTools_Ultimate.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Models
{
    public class AccessoryAbilityOptionDstData
    {
        private int _nDst;
        private int _nAdj;

        public int NDst
        {
            get => this._nDst;
            set => this._nDst = value;
        }
        public int NAdj
        {
            get => this._nAdj;
            set => this._nAdj = value;
        }

        public AccessoryAbilityOptionDstData(int nDst, int nAdj)
        {
            this._nDst = nDst;
            this._nAdj = nAdj;
        }
    }
    public class AccessoryAbilityOptionData
    {
        private int _nAbilityOption;
        private ObservableCollection<AccessoryAbilityOptionDstData> _dstData;

        public int NAbilityOption
        {
            get => this._nAbilityOption;
            set => this._nAbilityOption = value;
        }
        public ObservableCollection<AccessoryAbilityOptionDstData> DstData
        {
            get => this._dstData;
            set => this._dstData = value;
        }

        public AccessoryAbilityOptionData(int nAbilityOption, List<AccessoryAbilityOptionDstData> dstData)
        {
            this._nAbilityOption = nAbilityOption;
            this._dstData = [.. dstData];
        }
    }

    public class Accessory : IDisposable
    {
        private int _dwItemId;
        private ObservableCollection<AccessoryAbilityOptionData> _abilityOptionData;

        public int DwItemId
        {
            get => this._dwItemId;
            set => this._dwItemId = value;
        }
        public ObservableCollection<AccessoryAbilityOptionData> AbilityOptionData
        {
            get => this._abilityOptionData;
            set => this._abilityOptionData = value;
        }

        public Item? Item => ItemsService.Instance.Items.Where(x => x.Id == this.DwItemId).FirstOrDefault();

        public Accessory(int dwItemId, List<AccessoryAbilityOptionData> abilityOptionData)
        {
            this._dwItemId = dwItemId;
            this._abilityOptionData = [..abilityOptionData];
        }

        public void Dispose()
        {

        }
    }
}
