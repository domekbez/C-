using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11b
{
    public class ObservableCollection:IObservableCollection
    {
        public NotifingObject n;
        EventHandler p2 = (object sender, EventArgs e) =>
        {
            Console.WriteLine("Collection {0} changed,value:, operation: {2}", sender.ToString(), CollectionOperation.ValueChanged);

        };
        public event EventHandler<CollectionCahngedEventArgs> CollectionCahnged;
        EventHandler<CollectionCahngedEventArgs> p = (object sender, CollectionCahngedEventArgs e) =>
        {
            Console.WriteLine("Collection {0} changed,value: {1}, operation: {2}", sender.ToString(), e.Value, e.Operation);
        };
        public string Name { get; }
        List<object> lista;
        public ObservableCollection(string a)
        {
            n = new  NotifingObject();
            lista = new List<object>();
            Name = a;
        }
        public void Add(object value)
        {
            if (value.GetType().ToString()=="Lab11b.NotifingObject")
                n.NameChanged += p2;
            lista.Add(value);
            CollectionCahngedEventArgs pom = new CollectionCahngedEventArgs(CollectionOperation.Add, value);
            if(CollectionCahnged!=null)
            CollectionCahnged(this,pom);
        }
        public void Remove(object value)
        {
           
            lista.Remove(value);
            CollectionCahngedEventArgs pom = new CollectionCahngedEventArgs(CollectionOperation.Remove, value);
            if (CollectionCahnged != null)
                CollectionCahnged(this,pom);
        }
        public override string ToString()
        {
            return Name;
        }

    }
    public class SimpleWatcher
    {
        EventHandler<CollectionCahngedEventArgs> p = (object sender, CollectionCahngedEventArgs e) =>
        {
            Console.WriteLine("Collection changed");
        };
        public void Watch(IObservableCollection value)
        {
            value.CollectionCahnged += p;

        }
        public void StopWatching(IObservableCollection value)
        {
            value.CollectionCahnged -= p;
              

        }
    }
    public class SmartWatcher
    {
        EventHandler<CollectionCahngedEventArgs> p = (object sender, CollectionCahngedEventArgs e) =>
        {
            Console.WriteLine("Collection {0} changed,value: {1}, operation: {2}", sender.ToString(),e.Value,e.Operation);
            
        };
        public void Watch(IObservableCollection value)
        {
            value.CollectionCahnged += p;

        }
        public void StopWatching(IObservableCollection value)
        {
            value.CollectionCahnged -= p;


        }
        
       
    }
    public class NotifingObject : IChangeNotifing
    {
        public event EventHandler NameChanged;
        
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                EventArgs pom = new EventArgs();
                name = value;
                if(NameChanged!=null)
                NameChanged(this, pom);

            }

        }
        public override string ToString()
        {
            return Name;
        }

    }
}
