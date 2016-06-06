﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Forms = System.Windows.Forms;
using Office = Microsoft.Office.Interop.Visio;

namespace VisGeek.Apps.OfficeLineArt.VisioLineArt {
	internal class LineArt : OfficeLineArt.Ribbon.LineArt {
		// コンストラクター
		internal LineArt(Office.Application application) : base(Dispatcher.CurrentDispatcher) {
			this.Application = application;
		}

		// プロパティ
		public Office.Application Application { get; }

		// メソッド
		protected override void Sleep(TimeSpan timeSpan) {
			var dateTime = DateTime.Now + timeSpan;
			while (DateTime.Now < dateTime) {
				Forms.Application.DoEvents();
			}
		}

		protected override View.Field CreateField(Model.Field fieldModel, Color color) {
			return new Field(this, fieldModel, color);
		}
	}
}
