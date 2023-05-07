using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04._4hw
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IElement> elements = new List<IElement> { new Home(), new Bank(), new Factory() };
            IVisitor medical_Insurance = new Medical_Insurance();
            IVisitor robbery_Insurance = new Robbery_Insurance();
            IVisitor fire_Insurance = new Fire_Insurance();
            Client.ClientCode(elements, medical_Insurance);
            Client.ClientCode(elements, robbery_Insurance);
            Client.ClientCode(elements, fire_Insurance);
        }
    }
    public interface IElement
    {
        void Offer(IVisitor visitor);
    }
    public class Home : IElement
    {
        public void Offer(IVisitor visitor)
        {
            visitor.VisitHome(this);
        }
        public string HomeString()
        { 
            return "Дом";
        }
    }
    public class Factory : IElement
    {
        public void Offer(IVisitor visitor)
        { 
            visitor.VisitFactory(this);
        }
        public string FactoryString()
        { 
            return "Фабрика";
        }
    }
    public class Bank : IElement
    {
        public void Offer(IVisitor visitor)
        { 
            visitor.VisitBank(this); 
        }
        public string BankString()
        {
            return "Банк";
        }
    }
    public interface IVisitor
    {
        void VisitFactory(Factory element);
        void VisitHome(Home element);
        void VisitBank(Bank element);
    }
    class Medical_Insurance : IVisitor
    {
        public void VisitBank(Bank element)
        { 
            Console.WriteLine(element.BankString() + " <- предлоджение Медицинской страховки"); 
        }
        public void VisitFactory(Factory element)
        { 
            Console.WriteLine(element.FactoryString() + "<- предлоджение Медицинской страховки");
        }
        public void VisitHome(Home element)
        { 
            Console.WriteLine(element.HomeString() + " <- предлоджение Медицинской страховки"); 
        }
    }
    class Robbery_Insurance : IVisitor
    {
        public void VisitBank(Bank element)
        { 
            Console.WriteLine(element.BankString() + " <- предлоджение страховки Ограбления"); 
        }
        public void VisitFactory(Factory element)
        { 
            Console.WriteLine(element.FactoryString() + " <- предлоджение страховки Ограбления");
        }
        public void VisitHome(Home element)
        { 
            Console.WriteLine(element.HomeString() + " <- предлоджение страховки Ограбления");
        }
    }
    class Fire_Insurance : IVisitor
    {
        public void VisitBank(Bank element) 
        { 
            Console.WriteLine(element.BankString() + " <- предлоджение страховки Пожара");
        }
        public void VisitFactory(Factory element)
        { 
            Console.WriteLine(element.FactoryString() + " <- предлоджение страховки Пожара");
        }
        public void VisitHome(Home element) 
        { 
            Console.WriteLine(element.HomeString() + " <- предлоджение страховки Пожара");
        }
    }
    public class Client
    {
        public static void ClientCode(List<IElement> components, IVisitor visitor)
        {
            foreach (var t in components)
            {
                t.Offer(visitor);
            }              
        }
    }
}
