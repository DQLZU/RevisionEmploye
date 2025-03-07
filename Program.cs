using RevisionEmploye;

namespace RevisionEmploye
{
    public class Program
    {
        static void Main(string[] args)
        {

                try
                {
                    Employe employe = new Employe("3444645", "Daniela", "Quintana", new DateTime(1980, 11, 3), 50000, new DateTime(2000, 12, 1));
                    Employe employe1 = new Employe("1000001", "Lemoine", "Pierre", new DateTime(1975, 3, 20), 60000, new DateTime(2005, 6, 1));
                    Employe employe2 = new Employe("1000002", "Martin", "Claire", new DateTime(1985, 7, 15), 50000, new DateTime(2010, 9, 15));
                    Employe employe3 = new Employe("1000003", "Robert", "Michel", new DateTime(1990, 11, 10), 75000, new DateTime(2015, 3, 1));
                    Employe employe4 = new Employe("1000004", "Dupont", "Marie", new DateTime(1978, 5, 5), 65000, new DateTime(2000, 4, 25));
                    Employe employe5 = new Employe("1000005", "Durand", "Jacques", new DateTime(1992, 9, 22), 72000, new DateTime(2012, 8, 15));

                    List<Employe> employes = new List<Employe>();
                    employes.Add(employe);
                    employes.Add(employe1);
                    employes.Add(employe2);
                    employes.Add(employe3);
                    employes.Add(employe4);
                    employes.Add(employe5);
                    
 

                        for (int i = 0; i < employes.Count; i++)
                        {
                            Console.WriteLine(employes[i].ToString());
                            Console.WriteLine("**************************");
                            
                        }
                        Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur: " + ex.ToString ());

                }

        }
    }
}