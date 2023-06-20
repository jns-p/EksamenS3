using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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
            Model.Udlånere.Load();
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

        public void OpretLåner(string lånid, string email)
        {
            Låner låner = new Låner()
            {
                LånerId = lånid,
                Email = email
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
            if (antal > bog.Antal)
            {
                throw new Exception("Der er ikke så mange eksemplarer af den bog");
            }
            Udlånere.Add(udlån);
            Model.SaveChanges();
        }

        public void SletBog(Bog bog)
        {
            Bøger.Remove(bog);
            Model.SaveChanges();
        }

        public void SletLån(Udlån udlån)
        {
            Udlånere.Remove(udlån);
            Model.SaveChanges();
        }

        public void SletUdlåner(Låner låner)
        {
            Lånere.Remove(låner);
            Model.SaveChanges();
        }
    }
}
