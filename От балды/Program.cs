using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace От_балды
{
    class Program
    {
        static void Main(string[] args)
        {
            int trollHealth = 1000;
            int heroHealth = 500;
            int trollDamage = 50;
            int deadManHealth = 150;
            int deadManDamage = 20;
            int deadManCost = 25;
            int deadManExplosionDamage = 50;
            int lifeDrainDamage = 20;
            int lifeDrainHeal = lifeDrainDamage * 2;
            int damnedBolt = 60;

            Console.WriteLine($"Вы сражаетесь с троллем, у него {trollHealth} здоровья, после использования способностей \n " +
               $"тролль нанесет вам {trollDamage} урона, ваши способности позовляют вам призвать мертвеца, который будет\n принимать на себя урон и " +
               $"наносить ответный урон {deadManDamage}, призвав его, вы отдатиде ему частичку своей души, потеряв\n {deadManCost} здоровья," +
               $"мертвеца можно взорвать, он нанесет {deadManExplosionDamage} урона  и прекратит свое существование.\n вы можете " +
               $"направить свои темные силы, что бы нанести {lifeDrainDamage} урона и восстановить себе {lifeDrainHeal}\n здоровья, последняя из способностей " +
               $"посылает пучок энергии, он нанесет троллю {damnedBolt} урона ");

            while (trollHealth > 0 && heroHealth > 0)
            {
                string healthInfo = "Здоровье тролля:" + trollHealth + ", Ваше здоровье:" + heroHealth;
                string skillSet = "используйте способность :\n" +
                    "1 - призвать мертвеца\n" +
                    "2 - взорвать мертвеца\n" +
                    "3 - жизнесос\n" +
                    "4 - проклятый снаряд";

                Console.WriteLine(healthInfo);
                Console.WriteLine(skillSet);

                string userinput = Console.ReadLine();
                switch (userinput)
                {
                    case "1":
                        heroHealth -= trollDamage;
                        heroHealth -= deadManCost;

                        while (deadManHealth > 0)
                        {
                            Console.WriteLine(healthInfo);
                            Console.WriteLine("Что сделать с мертвецом? ");
                            Console.WriteLine("1 - призвать нового мертвеца ");
                            Console.WriteLine("2 -  взорвать мертвеца");
                            //deadManHealth -= trollDamage;
                            //trollHealth -= deadManDamage;

                            string userInput2;

                            userInput2 = Console.ReadLine();
                            switch (userInput2)
                            {
                                case "1":
                                    Console.WriteLine("нельзя призвать более одного мертвеца");
                                    break;
                                case "2":
                                    trollHealth -= deadManExplosionDamage;
                                    deadManHealth = 0;
                                    break;
                                //case "3":
                                //    trollHealth -= lifeDrainDamage;
                                //    deadManHealth -= trollDamage;
                                //    heroHealth += lifeDrainHeal;
                                //    break;
                                //case "4":
                                //    trollHealth -= damnedBolt;
                                //    deadManHealth -= trollDamage;
                                //    break;
                            }

                        }
                        break;
                    case "2":
                        Console.WriteLine("Сначала нужно призвать мертвеца");

                        break;
                    case "3":
                        trollHealth -= lifeDrainDamage;
                        heroHealth += lifeDrainHeal;
                        heroHealth -= trollDamage;
                        break;
                    case "4":
                        trollHealth -= damnedBolt;
                        heroHealth -= trollDamage;
                        break;
                    default:
                        Console.WriteLine(skillSet);
                        break;

                }
                if (heroHealth <= 0)
                {
                    Console.WriteLine("вы потерпели поражение");
                }
                else if (trollHealth <= 0)
                {
                    Console.WriteLine("Вы сразили тролля");
                }
            }
        }
    }
}
