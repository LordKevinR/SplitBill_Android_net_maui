namespace SplitBill
{
	public partial class MainPage : ContentPage
	{
		decimal bill;
		int tip;
		int noPersons = 1;
		public MainPage()
		{
			InitializeComponent();
		}
		private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
		{
			tip = (int)Slider.Value;
			tipSlider.Text = $"{tip}%";
			CalculateTotal();
		}
		private void EntryBill_TextChanged(object sender, TextChangedEventArgs e)
		{
			try
			{
				bill = decimal.Parse(EntryBill.Text);
				CalculateTotal();
			}
			catch
			{
				bill = 0;
			}
		}
		private void CalculateTotal()
		{
			//Total tip
			var totalTip = (bill * tip) / 100;

			//Tip by person
			var tipByPerson = (totalTip / noPersons);
			lblTip.Text = $"{tipByPerson:C}";

			//SubTotal
			var subtotal = (bill / noPersons);
			lblSubTotal.Text = $"{subtotal:C}";

			//Total
			var totalByPerson = (bill + totalTip) / noPersons;
			lblTotal.Text = $"{totalByPerson:C}";
		}
		private void btn10_Clicked(object sender, EventArgs e)
		{
			if (sender is Button)
			{
				var btn = (Button)sender;
				var percenTage = int.Parse(btn.Text.Replace("%", ""));

				Slider.Value = percenTage;
			}
		}
		private void btnMinus_Clicked(object sender, EventArgs e)
		{
			if (noPersons > 1) { noPersons -= 1; }
			lblnoPerson.Text = noPersons.ToString();
			CalculateTotal();
		}
		private void btnPlus_Clicked(object sender, EventArgs e)
		{
			noPersons += 1;
			lblnoPerson.Text = noPersons.ToString();
			CalculateTotal();
		}
		private void btnRestar_Clicked(object sender, EventArgs e)
		{
			noPersons = 1;
			lblnoPerson.Text = noPersons.ToString();
			CalculateTotal();
		}
	}

}
