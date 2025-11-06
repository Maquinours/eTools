using eTools_Ultimate.Helpers;
using eTools_Ultimate.Services;
using Microsoft.Extensions.DependencyInjection;
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

        public string DestIdentifier
        {
            get => Script.NumberToString(NDst, App.Services.GetRequiredService<DefinesService>().ReversedDestDefines);
            set 
            {
                if (Script.TryGetNumberFromString(value, out int val))
                    NDst = val;
            }
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

    public sealed class Accessory : IDisposable
    {
        private uint _dwItemId;
        private ObservableCollection<AccessoryAbilityOptionData> _abilityOptionData;

        public uint DwItemId
        {
            get => this._dwItemId;
            set => this._dwItemId = value;
        }
        public ObservableCollection<AccessoryAbilityOptionData> AbilityOptionData
        {
            get => this._abilityOptionData;
            set => this._abilityOptionData = value;
        }

        public Item? Item => App.Services.GetRequiredService<ItemsService>().Items.FirstOrDefault(x => x.Id == this.DwItemId);

        public Accessory(uint dwItemId, List<AccessoryAbilityOptionData> abilityOptionData)
        {
            _dwItemId = dwItemId;
            _abilityOptionData = [..abilityOptionData];
        }

        public void Dispose()
        {

        }
    }
}
