using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamenS3
{
    public class Func
    {
        public ObservableCollection<Bog> Bøger
        {
            get
            {
                return Model.Bøger.Local.ToObservableCollection();
            }
        }
        public ObservableCollection<Låner> Lånere
        {
            get
            {
                return Model.Lånere.Local.ToObservableCollection();
            }
        }
        public ObservableCollection<Udlån> Udlånere
        {
            get
            {
                return Model.Udlånere.Local.ToObservableCollection();
            }
        }
        private Model Model { get; set; } = new Model();
        public Func()
        {
            Model.Bøger.Load();
            Model.Lånere.Load();
        }

        public void OpretBog(string forfatter, string titel, string udgiver, int udgivår, int antal, int isbn)
        {
            Bog bog = new Bog()
            {
                Forfatter = forfatter,
                Titel = titel,
                Udgiver = udgiver,
                UdgivelsesÅr = udgivår,
                Antal = antal,
                ISBN = isbn,
            };
            Bøger.Add(bog);
            Model.SaveChanges();            
        }

        public void OpretLåner(string LånId, string Email)
        {
            Låner låner = new Låner()
            {
                LånerId = LånId,
                Email = Email
            };
            Lånere.Add(låner);
            Model.SaveChanges();
        }

        public void OpretUdlån(DateTime? dato, int antal, Låner låner, Bog bog)
        {
            Udlån udlån = new Udlån()
            {
                Dato = dato.Value,
                Antal = antal,
                Låner = låner,
                Bog = bog,
            };
            Udlånere.Add(udlån);
            Model.SaveChanges();
        }
    }
}
