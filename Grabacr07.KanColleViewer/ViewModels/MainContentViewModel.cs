﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grabacr07.KanColleViewer.ViewModels.Contents;
using Grabacr07.KanColleViewer.ViewModels.Contents.Docks;
using Grabacr07.KanColleViewer.ViewModels.Contents.Fleets;
using Livet;

namespace Grabacr07.KanColleViewer.ViewModels
{
	public class MainContentViewModel : ViewModel
	{
		public AdmiralViewModel Admiral { get; private set; }
		public MaterialsViewModel Materials { get; private set; }
		public ShipsViewModel Ships { get; private set; }
		public SlotItemsViewModel SlotItems { get; private set; }

		//public FleetsViewModel Fleets { get; private set; }
		//public RepairyardViewModel Repairyard { get; private set; }
		//public DockyardViewModel Dockyard { get; private set; }
		//public ExpeditionsViewModel Expeditions { get; private set; }

		public IList<TabItemViewModel> TabItems { get; set; }
		public IList<TabItemViewModel> SystemTabItems { get; set; }

		#region SelectedItem 変更通知プロパティ

		private TabItemViewModel _SelectedItem;

		public TabItemViewModel SelectedItem
		{
			get { return this._SelectedItem; }
			set
			{
				if (this._SelectedItem != value)
				{
					this._SelectedItem = value;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion


		public MainContentViewModel()
		{
			this.Admiral = new AdmiralViewModel();
			this.Materials = new MaterialsViewModel();
			this.Ships = new ShipsViewModel();
			this.SlotItems = new SlotItemsViewModel();

			var fleets = new FleetsViewModel();

			this.TabItems = new List<TabItemViewModel>
			{
				fleets,
				new RepairyardViewModel(),
				new DockyardViewModel(),
				new MissionsViewModel(),
				new ExpeditionsViewModel(fleets),
			};
			this.SystemTabItems = new List<TabItemViewModel>
			{
				new SettingsViewModel(),
			};
			this.SelectedItem = this.TabItems.FirstOrDefault();

			//this.Fleets = new FleetsViewModel();
			//this.Repairyard = new RepairyardViewModel();
			//this.Dockyard = new DockyardViewModel();
			//this.Expeditions = new ExpeditionsViewModel();
		}
	}
}
