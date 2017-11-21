using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using PublicationManager.Domain;
using Tynamix.ObjectFiller;

namespace PublicationManager.ViewModels
{
    public class MediumEntityViewModel : ObservableObject
    {
        private string website;
        private string publisher;
        private string name;

        public MediumEntityViewModel(Medium medium)
        {
           SetData(medium);
        }

        private void SetData(Medium medium)
        {
            this.Name = medium.Name;
            this.Website = medium.Website;
            this.Publisher = medium.Publisher;
        }

        public MediumEntityViewModel()
        {
            var medium = Randomizer<Medium>.Create();
            SetData(medium);
        }

        public string Website
        {
            get { return website; }
            set { Set(ref website, value); }
        }

        public string Publisher
        {
            get { return publisher; }
            set { Set(ref publisher, value); }
        }

        public string Name
        {
            get { return name; }
            set { Set(ref name, value); }
        }
    }
}
