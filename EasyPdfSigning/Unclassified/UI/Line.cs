// Copyright (c) 2009, Yves Goergen, http://unclassified.de
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, are permitted
// provided that the following conditions are met:
//
// * Redistributions of source code must retain the above copyright notice, this list of conditions
//   and the following disclaimer.
// * Redistributions in binary form must reproduce the above copyright notice, this list of
//   conditions and the following disclaimer in the documentation and/or other materials provided
//   with the distribution.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR
// IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
// CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
// THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR
// OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
// POSSIBILITY OF SUCH DAMAGE.

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Unclassified.UI
{
	public class Line : Control
	{
		#region Designer stuff
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion Designer stuff

		private LineOrientation orientation = LineOrientation.Horizontal;
		private Line3DStyle line3DStyle = Line3DStyle.Flat;
		private Color borderColor = SystemColors.ControlText;
		private Pen pen1, pen2;
		private int prevWidth, prevHeight;
		private bool internalResizing = false;
		private DashStyle dashStyle = DashStyle.Solid;

		public Line()
		{
			InitializeComponent();

			TabStop = false;

			pen1 = new Pen(borderColor, 1);
			pen2 = new Pen(borderColor, 1);
			prevWidth = Width;
			prevHeight = 100 /*Height*/;
			Orientation = LineOrientation.Horizontal;

			this.SizeChanged += new EventHandler(Line_SizeChanged);
		}

		protected override Size DefaultSize
		{
			get
			{
				return new Size(100, 1);
			}
		}

		void Line_SizeChanged(object sender, EventArgs e)
		{
			if (internalResizing) return;

			// Only remember the currently alterable dimensions
			if (orientation == LineOrientation.Horizontal)
			{
				prevWidth = Width;
			}
			else if (orientation == LineOrientation.Vertical)
			{
				prevHeight = Height;
			}
			else
			{
				prevWidth = Width;
				prevHeight = Height;
			}
		}

		#region New properties
		[DefaultValue(LineOrientation.Horizontal)]
		[Description("Line orientation"), Category("Appearance")]
		public LineOrientation Orientation
		{
			get
			{
				return orientation;
			}
			set
			{
				orientation = value;
				UpdateSize();
			}
		}

		[DefaultValue(Line3DStyle.Flat)]
		[Description("Border style"), Category("Appearance")]
		public Line3DStyle Line3DStyle
		{
			get
			{
				return line3DStyle;
			}
			set
			{
				line3DStyle = value;
				if (line3DStyle == Line3DStyle.Flat)
				{
					pen1 = new Pen(borderColor, 1);
					pen1.DashStyle = dashStyle;
				}
				else if (line3DStyle == Line3DStyle.Inset)
				{
					pen1 = new Pen(SystemColors.ControlLightLight, 1);
					pen2 = new Pen(SystemColors.ControlDark, 1);
					pen1.DashStyle = dashStyle;
					pen2.DashStyle = dashStyle;
				}
				else if (line3DStyle == Line3DStyle.Outset)
				{
					pen1 = new Pen(SystemColors.ControlDark, 1);
					pen2 = new Pen(SystemColors.ControlLightLight, 1);
					pen1.DashStyle = dashStyle;
					pen2.DashStyle = dashStyle;
				}
				UpdateSize();
			}
		}

		[Description("Border color for solid border style"), Category("Appearance")]
		public Color BorderColor
		{
			get
			{
				return borderColor;
			}
			set
			{
				borderColor = value;
				pen1 = new Pen(borderColor, 1);
				pen1.DashStyle = dashStyle;
				Invalidate();
			}
		}

		[Description("Border color for solid border style"), Category("Appearance")]
		public DashStyle DashStyle
		{
			get
			{
				return pen1.DashStyle;
			}
			set
			{
				dashStyle = value;
				pen1.DashStyle = value;
				pen2.DashStyle = value;
				Invalidate();
			}
		}

		//public new Size Size
		//{
		//    get
		//    {
		//        return base.Size;
		//    }
		//    set
		//    {
		//        int lineWidth = (borderStyle == BorderStyle.Fixed3D) ? 2 : 1;
		//        if (orientation == LineOrientation.Horizontal)
		//        {
		//            base.Size = new Size(value.Width, lineWidth);
		//        }
		//        else if (orientation == LineOrientation.Vertical)
		//        {
		//            base.Size = new Size(lineWidth, value.Height);
		//        }
		//        else
		//        {
		//            base.Size = value;
		//        }
		//    }
		//}
		#endregion New properties

		#region Disabled properties
		[Browsable(false)]
		public override Font Font
		{
			get
			{
				return base.Font;
			}
			set
			{
				base.Font = value;
			}
		}

		[Browsable(false)]
		public override Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
			}
		}

		[Browsable(false)]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}

		[Browsable(false)]
		public new int TabIndex
		{
			get
			{
				return base.TabIndex;
			}
			set
			{
				base.TabIndex = value;
			}
		}

		[Browsable(false)]
		public new bool TabStop
		{
			get
			{
				return base.TabStop;
			}
			set
			{
				base.TabStop = value;
			}
		}
		#endregion Disabled properties

		private void UpdateSize()
		{
			internalResizing = true;
			int lineWidth = (line3DStyle != Line3DStyle.Flat) ? 2 : 1;
			if (orientation == LineOrientation.Horizontal)
			{
				Width = prevWidth;
				Height = lineWidth;
				//MaximumSize = new Size(0, lineWidth);
			}
			else if (orientation == LineOrientation.Vertical)
			{
				Width = lineWidth;
				Height = prevHeight;
				//MaximumSize = new Size(lineWidth, 0);
			}
			else
			{
				Width = prevWidth;
				Height = prevHeight;
				//MaximumSize = new Size();
			}
			internalResizing = false;
			Invalidate();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			if (line3DStyle == Line3DStyle.Flat)
			{
				if (orientation == LineOrientation.Horizontal)
				{
					pe.Graphics.DrawLine(pen1, 0, 0, Width - 1, 0);
				}
				else if (orientation == LineOrientation.Vertical)
				{
					pe.Graphics.DrawLine(pen1, 0, 0, 0, Height - 1);
				}
				else if (orientation == LineOrientation.DiagonalUp)
				{
					pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
					pe.Graphics.DrawLine(pen1, 0, Height - 1, Width - 1, 0);
				}
				else if (orientation == LineOrientation.DiagonalDown)
				{
					pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
					pe.Graphics.DrawLine(pen1, 0, 0, Width - 1, Height - 1);
				}
			}
			else   // 3D - colours are set in the Line3DStyle_Set property
			{
				if (orientation == LineOrientation.Horizontal)
				{
					pe.Graphics.DrawLine(pen2, 0, 0, Width - 1, 0);
					pe.Graphics.DrawLine(pen1, 0, 1, Width - 1, 1);
				}
				else if (orientation == LineOrientation.Vertical)
				{
					pe.Graphics.DrawLine(pen2, 0, 0, 0, Height - 1);
					pe.Graphics.DrawLine(pen1, 1, 0, 1, Height - 1);
				}
				else if (orientation == LineOrientation.DiagonalUp)
				{
					pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
					pe.Graphics.DrawLine(pen2, 0, Height - 2, Width - 2, 0);
					pe.Graphics.DrawLine(pen1, 1, Height - 1, Width - 1, 1);
				}
				else if (orientation == LineOrientation.DiagonalDown)
				{
					pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
					pe.Graphics.DrawLine(pen2, 1, 0, Width - 1, Height - 2);
					pe.Graphics.DrawLine(pen1, 0, 1, Width - 2, Height - 1);
				}
			}

			// OnPaint-Basisklasse wird aufgerufen
			base.OnPaint(pe);
		}

		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			//base.OnPaintBackground(pevent);
		}

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x20 /* WS_EX_TRANSPARENT */;
				return cp;
			}
		}
	}

	public enum LineOrientation
	{
		Horizontal,
		Vertical,
		DiagonalUp,
		DiagonalDown
	}

	public enum Line3DStyle
	{
		Flat,
		Inset,
		Outset
	}
}
