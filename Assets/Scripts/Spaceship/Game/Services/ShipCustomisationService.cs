﻿using System;
using System.Linq;
using Spaceship.Game.Model;
using Spaceship.Settings.Ship;

namespace Spaceship.Game.Services
{
    public class ShipCustomisationService
    {
        public Ship ShipA { get; private set; }
        public Ship ShipB { get; private set; }

        public ShipCustomisationService(ShipSettings shipASettings, ShipSettings shipBSettings)
        {
            ShipA = new Ship(shipASettings);
            ShipB = new Ship(shipBSettings);
        }

        public void ApplyModules()
        {
            ApplyShipModules(ShipA);
            ApplyShipModules(ShipA);
        }

        public void ReplaceComponent(Ship ship, int index, ComponentSettings componentSettings)
        {
            if (componentSettings.Def == ComponentDef.Module)
            {
                ReplaceModule(ship, index, (ModuleSettings)componentSettings);
            }
            
            if (componentSettings.Def == ComponentDef.Weapon)
            {
                ReplaceWeapon(ship, index, (WeaponSettings)componentSettings);
            }
        }

        private void ReplaceModule(Ship ship, int index, ModuleSettings moduleSettings)
        {
            ship.Modules[index] = new Module(moduleSettings);
        }

        private void ReplaceWeapon(Ship ship, int index, WeaponSettings weaponSettings)
        {
            ship.Weapons[index] = new Weapon(weaponSettings);
        }
        
        private void ApplyShipModules(Ship ship)
        {
            foreach (var module in ship.Modules.Where(m => m != null))
            {
                switch (module.StatName)
                {
                    case "Health":
                        ship.Health = module.ApplyModification(ship.Health);
                        break;
                    case "Shield":
                        ship.Shield = module.ApplyModification(ship.Shield);
                        break;
                    case "ShieldRegenPerSec":
                        ship.ShieldRegenPerSec = module.ApplyModification(ship.ShieldRegenPerSec);
                        break;
                    case "Recharge":
                    {
                        foreach (var weapon in ship.Weapons.Where(w => w != null))
                        {
                            weapon.Recharge = module.ApplyModification(weapon.Recharge);
                        }
                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException(
                            $"Not founded stat {module.StatName}, module {module.Id}");
                }
            }
        }
    }
}