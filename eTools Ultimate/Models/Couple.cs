using eTools_Ultimate.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Models
{
    public class CoupleLevelItem(string nItemId, string nSex, int nFlags, int nLife, int nNum) : INotifyPropertyChanged
    {
        private string _nItemId = nItemId;
        private string _nSex = nSex;
        private int _nFlags = nFlags;
        private int _nLife = nLife;
        private int _nNum = nNum;

        public string NItemId
        {
            get => this._nItemId;
            set
            {
                if(this.NItemId != value)
                {
                    this._nItemId = value;
                    this.NotifyPropertyChanged();
                }
            }
        }
        public string NSex
        {
            get => this._nSex;
            set
            {
                if(this.NSex != value)
                {
                    this._nSex = value;
                    this.NotifyPropertyChanged();
                }
            }
        }
        public int NFlags
        {
            get => this._nFlags;
            set
            {
                if(this.NFlags != value)
                {
                    this._nFlags = value;
                    this.NotifyPropertyChanged();
                }
            }
        }
        public int NLife
        {
            get => this._nLife;
            set
            {
                if(this.NLife != value)
                {
                    this._nLife = value;
                    this.NotifyPropertyChanged();
                }
            }
        }
        public int NNum
        {
            get => this._nNum;
            set
            {
                if(this.NNum != value)
                {
                    this._nNum = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class CoupleLevelSkill(string nSkillKind, int nSkillLevel) : INotifyPropertyChanged
    {
        private string _nSkillKind = nSkillKind;
        private int _nSkillLevel = nSkillLevel;

        public string NSkillKind
        {
            get => this._nSkillKind;
            set
            {
                if(this.NSkillKind != value)
                {
                    this._nSkillKind = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public int NSkillLevel
        {
            get => this._nSkillLevel;
            set
            {
                if(this.NSkillLevel != value)
                {
                    this._nSkillLevel = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public CoupleLevelSkill Clone()
        {
            return new CoupleLevelSkill(nSkillKind: this.NSkillKind, nSkillLevel: this.NSkillLevel);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class CoupleLevel(int nExp, List<CoupleLevelItem> items, List<CoupleLevelSkill> skills) : INotifyPropertyChanged
    {
        private int _nExp = nExp;
        private readonly ObservableCollection<CoupleLevelItem> _items = [.. items];
        private readonly ObservableCollection<CoupleLevelSkill> _skills = [.. skills];

        public int NExp
        {
            get => this._nExp;
            set
            {
                if(this.NExp != value)
                {
                    this._nExp = value;
                    this.NotifyPropertyChanged();
                }
            }
        }
        public ObservableCollection<CoupleLevelItem> Items => this._items;
        public ObservableCollection<CoupleLevelSkill> Skills => this._skills;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    class Couple
    {
        private readonly List<CoupleLevel> _levels;
        private readonly List<string> _skillKinds;

        public List<CoupleLevel> Levels => this._levels;
        public List<string> SkillKinds => this._skillKinds;
    }
}
