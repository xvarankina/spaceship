using Game.Services;
using Settings.UI;
using UI.Widgets;
using UnityEngine;

namespace UI.Screens
{
    public class ScreenCustomisation : AbstractScreen
    {
        [SerializeField] private WidgetShipCustomisation _widgetShipCustomisationA;
        [SerializeField] private WidgetShipCustomisation _widgetShipCustomisationB;

        private ShipCustomisationService _shipCustomisationService;

        private void Start()
        {
            _shipCustomisationService = ServiceLocator.Get<ShipCustomisationService>();
            
            _widgetShipCustomisationA.Init(_shipCustomisationService.ShipA);
            _widgetShipCustomisationB.Init(_shipCustomisationService.ShipB);
        }

        public void OnClick()
        {
            _shipCustomisationService.ApplyModules();
            Service.Create(ScreenDef.Battle);
        }
    }
}
