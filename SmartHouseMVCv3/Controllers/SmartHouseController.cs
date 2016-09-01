using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartHouseMVCv3.Interfaces;
using SmartHouseMVCv3.Enum;
using SmartHouseMVCv3.AbstractClass;
using SmartHouseMVCv3.Models;

namespace SmartHouseMVCv3.Controllers
{
    
    public class SmartHouseController : Controller
    {
        IDictionary<int, Device> devicesDictionary;
        private int id;
        public void DeviceControl(int id, IDictionary<int, Device> devicesDictionary)
        {
            this.id = id;
            this.devicesDictionary = devicesDictionary;
        }
        // GET: SmartHouse
        public ActionResult Index()
        {
            if (Session["Devices"] == null)
            {
                devicesDictionary = new SortedDictionary<int, Device>();
                devicesDictionary.Add(1, new Lamp(false, "Лампа", BrightnessLevel.High));
                Session["Devices"] = devicesDictionary;
                Session["NextId"] = 2;
            }
            else
            {
                devicesDictionary = (SortedDictionary<int, Device>)Session["Devices"];
            }
            SelectListItem[] devicesList = new SelectListItem[1];
            devicesList[0] = new SelectListItem { Text = "Лампа", Value = "lamp", Selected = true };
            ViewBag.DevicesList = devicesList;
            return View(devicesDictionary);
        }
       
        public ActionResult Add(string deviceType)
        {
            Device newDevice;
            switch (deviceType)
            {
                default:
                    newDevice = new Lamp(false, "Лампа", BrightnessLevel.High);
                    break;
            }
            int id = (int)Session["NextId"];
            IDictionary<int, Device> devicesDictionary = (SortedDictionary<int, Device>)Session["Devices"];
            devicesDictionary.Add(id, newDevice); // Добавление девайса в коллекцию
            Session["Devices"] = devicesDictionary;
            id++;
            Session["NextId"] = id;
           return RedirectToAction("Index");
        }

        public ActionResult SetLampMode(int id, string lampMode)
        {
            IDictionary<int, Device> devicesDictionary = (SortedDictionary<int, Device>)Session["Devices"];
            ILampMode l = (ILampMode)devicesDictionary[id];
            Session["LampMode"] = lampMode;
            switch (lampMode)
            {
                case "High":
                    l.SetHighBrightness();
                    break;
                case "Medium":
                    l.SetMediumBrightness();
                    break;
                case "Low":
                    l.SetLowBrightness();
                    break;
            }
            Session["Devices"] = devicesDictionary;
            return RedirectToAction("Index");
        }

        public ActionResult OnMode (int id)
        {
            IDictionary<int, Device> devicesDictionary = (SortedDictionary<int, Device>)Session["Devices"];
            devicesDictionary[id].OnDevice();
            return RedirectToAction("Index");
        }

        public ActionResult OffMode(int id)
        {
            IDictionary<int, Device> devicesDictionary = (SortedDictionary<int, Device>)Session["Devices"];
            devicesDictionary[id].OffDevice();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            IDictionary<int, Device> devicesDictionary = (SortedDictionary<int, Device>)Session["Devices"];
            devicesDictionary.Remove(id);
            Session["Devices"] = devicesDictionary;
            return RedirectToAction("Index");
        }


    }
}