using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using 管理系统.Model;

namespace 管理系统.Service
{
    public class XmlDataService : IDataService
    {
        public List<Dish> GetAllDishes()
        {
            List<Dish> res = new List<Dish>();
            string xmlFileName = System.IO.Path.Combine(Environment.CurrentDirectory, @"Data\Data.xml");
            XDocument xdoc = XDocument.Load(xmlFileName);

            IEnumerable<XElement> dishes = xdoc.Descendants("Dish");
            foreach (XElement d in dishes)
            {
                Dish dish = new Dish();
                dish.Name = d.Element("Name").Value;
                dish.Category = d.Element("Category").Value;
                dish.Comment = d.Element("Comment").Value;
                dish.Score = double.Parse(d.Element("Score").Value);
                res.Add(dish);
            }
            return res;
        }
    }
}
