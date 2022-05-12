using la_mia_pizzeria_static.Models;

namespace la_mia_pizzeria_static.Utils
{
    public class PizzaData
    {
        private static List<Pizza> pizze;
        public static List<Pizza> GetPizze()
        {
            if (PizzaData.pizze != null) 
            { 
                return PizzaData.pizze;
            }

            List<Pizza> nuovaListaPizze = new List<Pizza>();

            Pizza pizza1 = new Pizza("Margherita", "Pomodoro San Marzano DOP, Fiordilatte di Agerola, Parmigiano Reggiano (oltre 30mesi) Basilico, Olio extravergine di oliva DOP.", "https://blog.giallozafferano.it/francinut87/wp-content/uploads/2021/04/Pizza-margherita-fatta-in-casa-orizzontale.jpg", 4.50);
            Pizza pizza2 = new Pizza("Diavola", "Pomodoro San Marzano DOP, Salsiccia secca piccante, Fiordilatte di Agerola, Scaglie di cacioricotta piccante, Basilico, Olio extravergine di oliva DOP.", "https://media-cdn.tripadvisor.com/media/photo-s/0c/81/a4/0d/pizza-diavola.jpg", 5.50);
            Pizza pizza3 = new Pizza("Capricciosa", "Fiordilatte di Agerola, Pomodoro San Marzano DOP, Salame Napoli, Prosciutto cotto Praga, Carciofini fatti in casa, Funghi freschi, Olive nere Itrane, Basilico; Olio extravergine di oliva DOP.", "https://www.lucianopignataro.it/wp-content/uploads/2020/11/Pizzeria-Carmnella-Capricciosa-e1606066344978.jpg", 6.00);
            Pizza pizza4 = new Pizza("Ortolana", "Crema di peperoni, Fiordilatte di Agerola, Mix di verdure al forno, Parmigiano Reggiano, Basilico, olio extravergine di oliva DOP.", "https://media-cdn.tripadvisor.com/media/photo-s/0e/50/48/d2/pizza-ortolana.jpg", 6.50);
            nuovaListaPizze.Add(pizza1);
            nuovaListaPizze.Add(pizza2);
            nuovaListaPizze.Add(pizza3);
            nuovaListaPizze.Add(pizza4);

            PizzaData.pizze = nuovaListaPizze;
            return PizzaData.pizze;
        }
    }
}
