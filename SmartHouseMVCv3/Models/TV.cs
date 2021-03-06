﻿using SmartHouseMVCv3.AbstractClass;
using SmartHouseMVCv3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouseMVCv3.Models
{
    public class TV : Device, ISetVolume, ISetChannel
    {
        private int temp;
        private int ch;
        public TV(bool status, string name)
            : base(status, name)
        {

        }
        public int Volume
        {
            get
            {
                return temp;
            }

            set
            {
                if (value >= 0 && value <= 100)
                {
                    temp = value;
                }
            }
        }
        public void SetVolume(int input)
        {
            if (Status)
            {
                temp = input;
            }
        }
        public int Channel
        {
            get
            {
                return ch;
            }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    ch = value;
                }
            }
        }
        public void SetChannel(int input)
        {
            if (Status)
            {
                ch = input;
            }
        }
        public void NextChannel()
        {
            if (Status)
            {

                if (ch < 100)
                {
                    ch += 1;
                }
            }
        }
        public void PreviousChannel()
        {
            if (Status)
            {

                if (ch > 1)
                {
                    ch -= 1;
                }
                else
                {
                    ch = 0;
                }
            }
        }
        public void UpVolume()
        {
            if (Status)
            {

                if (temp < 100)
                {
                    temp += 1;
                }
            }
        }
        public void LessVolume()
        {
            if (Status)
            {

                if (temp > 1)
                {
                    temp -= 1;
                }
                else
                {
                    temp = 0;
                }
            }
        }
        public override string ToString()
        {
            return base.ToString() + ", Громкость: " + temp + ", \nКанал: " + ch;
        }
    }
}