namespace WebShop.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Webshop.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebShop.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebShop.Models.ApplicationDbContext context)
        {
            context.Framework.AddOrUpdate<ProgrammingFramework>(c => c.Name, new ProgrammingFramework() { Name = ".NET Microframework 4.2" });
            context.Framework.AddOrUpdate<ProgrammingFramework>(c => c.Name, new ProgrammingFramework() { Name = ".NET Microframework 4.3" });
            context.Framework.AddOrUpdate<ProgrammingFramework>(c => c.Name, new ProgrammingFramework() { Name = "Mono" });
            context.Framework.AddOrUpdate<ProgrammingFramework>(c => c.Name, new ProgrammingFramework() { Name = "Python" });
            context.Framework.AddOrUpdate<ProgrammingFramework>(c => c.Name, new ProgrammingFramework() { Name = "Windows Universal Apps" });
            context.SaveChanges();

            context.OperatingSystem.AddOrUpdate<DeviceOperatingSystem>(c => c.Name, new DeviceOperatingSystem() { Name = "Linux" });
            context.OperatingSystem.AddOrUpdate<DeviceOperatingSystem>(c => c.Name, new DeviceOperatingSystem() { Name = "Windows 10 for IOT" });
            context.OperatingSystem.AddOrUpdate<DeviceOperatingSystem>(c => c.Name, new DeviceOperatingSystem() { Name = "mBed" });
            context.OperatingSystem.AddOrUpdate<DeviceOperatingSystem>(c => c.Name, new DeviceOperatingSystem() { Name = "Contiki" });
            context.OperatingSystem.AddOrUpdate<DeviceOperatingSystem>(c => c.Name, new DeviceOperatingSystem() { Name = "ArdOS" });
            context.SaveChanges();

            context.Device.AddOrUpdate<Device>(c => c.Name, new Device() { Name = "Linux" });

            /*
            1;Arduino ADK Rev3 - ATmega2560;35;4;120;ARD-ADK-REV3-1-800x533.jpg;5;4;De Arduino ADK is gebaseerd op de ATmega2560 chip en heet een USB host interface om te kunnen verbinden met Android gebaseerde apparaten, gebaseerd op de MAX3421e. Het board heeft 54 digitale input/output pinnen (waarvan er 15 voor PWM kunnen worden gebruikt), 16 analoge input pinnen, 4 UARTs (hardware seri�le poorten), een 16 MHz kristal oscillator, een USB-aansluiting, een power jack, een ICSP header, en een resetknop.
2;Arduino Esplora;49;7;33;ARD-ESPLORA-1-800x533.jpg;5;4;De Arduino Esplora is een kant en klare, makkelijk vast te houden controller welke je de oneindige mogelijkheden leert ontdekken in de wereld van sensoren en schakelaars, zonder met breadboards, soldeer of kabels aan de slag hoeft te gaan.
3;Raspberry Pi 2 Model B 1GB;39;9;140;RPF-RP2B1GB-2-800x533.jpg;1-2;5;De Raspberry Pi 2 Model B is de laatste telg in de Raspberry Pi familie. Hij beschikt over een BCM2836 ARMv7 Quad Core Processor op 900MHz en 1GB RAM. Hiermee is de Raspberry Pi 2 Model B 6x sneller dan zijn voorgangers en heeft hij twee keer zoveel geheugen.Hij heeft dezelfde board layout als de Model B+ , dus alle behuizingen en addon boards ontworpen voor de Model B+ zijn volledig compatibel. GPIO is 100% compatibel met de Model B+ en Model A+ boards en de eerste 26 pinnen zijn identiek aan de Model B en Model A om volledige compatibiliteit te garanderen over alle boards.
4;Arduino Mini met headers - ATmega328;19;3;140;ARD-MINI-H-2-800x533.jpg;5;4;De Arduino Mini is een microcontroller board gebaseerd op de ATmega328, bedoeld voor gebruik op breadboards of wanneer ruimte een probleem is. Het board heeft 14 digitale input/output pinnen (waarvan 6 kunnen worden gebruikt als PWM outputs), 8 analoge ingangen, een 16 MHz resonator. Hij kan worden geprogrammeerd met een USB of RS232 naar TTL seri�le adapter.
5;Raspberry Pi Model A+ 256MB;25;4;180;RPI-MOD-A+1-800x533.jpg;1;5;De Raspberry Pi Model A+ is een uitgeklede versie van de Raspberry Pi Model B+ zonder Ethernet, ��n USB poort en 256MB RAM. Het weglaten van bepaalde features in de Raspberry Pi Model A+ heeft als resultaat dat deze $10 goedkoper is dan de Model B+ en bijna een derde minder energie gebruikt. Dit lage energieverbruik maakt hem ideaal voor projecten welke op batterijen of zonne-energie werken. Naast het lagere energieverbruik is hij ook 21mm minder lang geworden (65mm in vergelijking met 86mm van de Model A).
            */
        }

        private List<Device> GetDevices()
        {
            List<Device> devices = new List<Device>();
            Device d1 = new Device()
            {
                
            };

        }
    }
}
