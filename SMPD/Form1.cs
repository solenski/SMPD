using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SMPD.FeatureSelection;
using System.Diagnostics;
using System.Globalization;
using Accord.Math;
using SMPD.Klasyfikatory;
using SMPD.Tests;

namespace SMPD
{
    public partial class Form1 : Form
    {
        private List<MapleSample> _wybraneCechy = new MapleOakExampleFileReader().ReadSamples().ToList();
        private List<double[]> _acer;
        private List<double[]> _quercus;
        private int _featureCount = 1;

        public Form1()
        {
            InitializeComponent();
            _acer = _wybraneCechy.Where(x => x.label.StartsWith("Acer")).SelectMany(x => x.samples).ToList();
            _quercus = _wybraneCechy.Where(x => x.label.StartsWith("Quercus")).SelectMany(x => x.samples).ToList();
        }



        private async void fisher_click(object sender, EventArgs e)
        {
            this._featureCount = int.Parse(this.maskedTextBox1.Text);

            this.button1.Enabled = false;

            var result = await Task.Factory.StartNew(() => new FisherSelektorCech(_featureCount).WyselekcjonujCechy(_acer, _quercus));
            ZapamietajWybraneCechy(result);
            this.button1.Enabled = true;

            this.textBox1.Text = result.Features.Aggregate(string.Empty, (s, i) => s + ',' + i.ToString());
        }

        private void ZapamietajWybraneCechy(WynikSelektoraCech result)
        {
            this._wybraneCechy = _wybraneCechy.Select(sample => new MapleSample
            {
                label = sample.label,
                samples = sample.samples.Where((t, i) => result.Features.Contains(i)).ToArray().ToList().ToArray()
            }).ToList();

            this._acer = _acer.Select(sample => sample.Where((t, i) => result.Features.Contains(i)).ToArray()).ToList();
            this._quercus = _quercus.Select(sample => sample.Where((t, i) => result.Features.Contains(i)).ToArray()).ToList();
        }


        private async void sfs_click(object sender, EventArgs e)
        {
            this._featureCount = int.Parse(this.maskedTextBox1.Text);

            this.button2.Enabled = false;
            var result = await Task.Factory.StartNew(
                () => new SelektorSFS(
                    _featureCount, (enumerable, enumerable1)
                        => new FisherSelektorCech(_featureCount)
                            .WyselekcjonujCechy(enumerable, enumerable1)).SelectFeatures(_acer, _quercus));
            this.button2.Enabled = true;
            this.textBox4.Text = result.Features.Aggregate(string.Empty, (s, i) => s + i.ToString() + ',');

        }



        private KlasyfikatorNajblizszegoSasiada nnClassifier;
        private int _nnEndIndexA;
        private int _nnEndIndexQ;


        private void najblizszegoSasiadaTrenuj(object sender, EventArgs e)
        {
            var percent = double.Parse(this.maskedTextBox2.Text) / 100;
            _nnEndIndexA = Convert.ToInt32(this._acer.Count * percent);
            _nnEndIndexQ = Convert.ToInt32(this._quercus.Count * percent);



            var inputs = this._acer.GetRange(0, _nnEndIndexA).Concat(this._quercus.GetRange(0, _nnEndIndexQ)).ToArray();
            var outputs = this._acer.GetRange(0, _nnEndIndexA).Select(_ => 0)
                .Concat(this._quercus.GetRange(0, _nnEndIndexQ).Select(_ => 1)).ToArray();

            this.nnClassifier = new KlasyfikatorNajblizszegoSasiada(2, inputs, outputs, Distance.Euclidean);
        }

        private void najblizszegoSasiadaKlasyfikuj(object sender, EventArgs e)
        {
            var inputs = this._acer.GetRange(_nnEndIndexA, this._acer.Count - _nnEndIndexA).Concat(this._quercus.GetRange(_nnEndIndexQ, this._quercus.Count - _nnEndIndexQ)).ToArray();
            var outputs = this._acer.GetRange(_nnEndIndexA, this._acer.Count - _nnEndIndexA).Select(_ => 0)
                .Concat(this._quercus.GetRange(_nnEndIndexQ, this._quercus.Count - _nnEndIndexQ).Select(_ => 1)).ToArray();
            var results = inputs.Select(x => this.nnClassifier.Klasyfikuj(x)).ToArray();

            var accuracy = (double)outputs.Where((t, i) => t == results[i]).Count() / (double)outputs.Length;
            textBox7.Text = accuracy * 100 + "%";
        }

        private KlasyfikatorKNN knnClassifier;
        private int _nnEndIndexAk;
        private int _nnEndIndexQk;
        private int _nnEndIndexAnM;
        private int _nnEndIndexQnM;
        private KlasyfikatorNajblizszejSredniej nmClassifier;


        private void nNajblizszychSasiadowTrenuj(object sender, EventArgs e)
        {
            var percent = double.Parse(this.maskedTextBox3.Text) / 100;
            _nnEndIndexAk = Convert.ToInt32(this._acer.Count * percent);
            _nnEndIndexQk = Convert.ToInt32(this._quercus.Count * percent);
            var k = int.Parse(this.textBox9.Text);


            var inputs = this._acer.GetRange(0, _nnEndIndexAk).Concat(this._quercus.GetRange(0, _nnEndIndexQk)).ToArray();
            var outputs = this._acer.GetRange(0, _nnEndIndexAk).Select(_ => 0)
                .Concat(this._quercus.GetRange(0, _nnEndIndexQk).Select(_ => 1)).ToArray();

            this.knnClassifier = new KlasyfikatorKNN(k, 2, inputs, outputs, Distance.Euclidean);
        }

        private void nNajblizszySasiadowKlasyfikuj(object sender, EventArgs e)
        {
            var inputs = this._acer.GetRange(_nnEndIndexAk, this._acer.Count - _nnEndIndexAk).Concat(this._quercus.GetRange(_nnEndIndexQk, this._quercus.Count - _nnEndIndexQk)).ToArray();
            var outputs = this._acer.GetRange(_nnEndIndexAk, this._acer.Count - _nnEndIndexAk).Select(_ => 0)
                .Concat(this._quercus.GetRange(_nnEndIndexQk, this._quercus.Count - _nnEndIndexQk).Select(_ => 1)).ToArray();
            var results = inputs.Select(x => this.knnClassifier.Klasyfikuj(x)).ToArray();

            var accuracy = (double)outputs.Where((t, i) => t == results[i]).Count() / (double)outputs.Length;
            textBox8.Text = accuracy * 100 + "%";
        }

        private void nSrednichTrenuj(object sender, EventArgs e)
        {
            var percent = double.Parse(this.nMSamplePercent.Text) / 100;
            _nnEndIndexAnM = Convert.ToInt32(this._acer.Count * percent);
            _nnEndIndexQnM = Convert.ToInt32(this._quercus.Count * percent);


            var inputs = this._acer.GetRange(0, _nnEndIndexAnM).Concat(this._quercus.GetRange(0, _nnEndIndexQnM)).ToArray();
            var outputs = this._acer.GetRange(0, _nnEndIndexAnM).Select(_ => 0)
                .Concat(this._quercus.GetRange(0, _nnEndIndexQnM).Select(_ => 1)).ToArray();

            this.nmClassifier = new KlasyfikatorNajblizszejSredniej(2, inputs, outputs, Distance.Euclidean);

        }

        private void nNablizszychSasiadowKlasyfikuj_Click(object sender, EventArgs e)
        {
            var inputs = this._acer.GetRange(_nnEndIndexAnM, this._acer.Count - _nnEndIndexAnM).Concat(this._quercus.GetRange(_nnEndIndexQnM, this._quercus.Count - _nnEndIndexQnM)).ToArray();
            var outputs = this._acer.GetRange(_nnEndIndexAnM, this._acer.Count - _nnEndIndexAnM).Select(_ => 0)
                .Concat(this._quercus.GetRange(_nnEndIndexQnM, this._quercus.Count - _nnEndIndexQnM).Select(_ => 1)).ToArray();
            var results = inputs.Select(x => this.nmClassifier.Klasyfikuj(x)).ToArray();

            var accuracy = (double)outputs.Where((t, i) => t == results[i]).Count() / (double)outputs.Length;
            nMeanResult.Text = accuracy * 100 + "%";
        }

        private void KroswalidacjaNajblizszySasiad(object sender, EventArgs e)
        {
            this.kroswalidacjaNablizszegoSasiadaWynik.Text = new Kroswalidacja<KlasyfikatorNajblizszegoSasiada>(this._wybraneCechy, 1).Test(int.Parse(this.kroswalidacjaNajblizszegoSasiadaN.Text)).ToString(CultureInfo.InvariantCulture) + '%';


        }

        private void KroswalidacjakNajblizszychSasiadow(object sender, EventArgs e)
        {
            this.kroswalidacjakNajblizszychSasiadowWynik.Text = new Kroswalidacja<KlasyfikatorKNN>(this._wybraneCechy, int.Parse(this.kroswalidacjaNablizszychSasiadowK.Text)).Test(int.Parse(this.klasyfikatorKNajblizszychSasiadowN.Text)).ToString(CultureInfo.InvariantCulture) + '%';

        }

        private void KrosWalidacjaNajbliższejSredniej(object sender, EventArgs e)
        {
            this.kroswalidacjaNajblizszejSredniekWynik.Text = new Kroswalidacja<KlasyfikatorNajblizszejSredniej>(this._wybraneCechy, 1).Test(int.Parse(this.kroswalidacjaNajblizszejSredniejN.Text)).ToString(CultureInfo.InvariantCulture) + '%';

        }


        private void bootstrapNajblizszegoSasiadaTest_Click(object sender, EventArgs e)
        {
            this.bootstrapNajblizszegoSasiadaWynik.Text = new Bootstrap<KlasyfikatorNajblizszegoSasiada>(this._wybraneCechy, 1)
                                                              .Test(int.Parse(this.bootstrapnajblizszychSasiadowIle.Text))
                                                              .ToString(CultureInfo.InvariantCulture) + '%';
        }

        private void bootstrapKNajblizszySasiadowTest_Click(object sender, EventArgs e)
        {
            this.bootstrapNajblizszychSasiadowWynik.Text =
                new Bootstrap<KlasyfikatorKNN>(this._wybraneCechy, int.Parse(this.boostrapkNajblizszychSasiadowK.Text))
                    .Test(int.Parse(this.bootstrapnajblizszychSasiadowIle.Text)).ToString(CultureInfo.InvariantCulture) + '%';
        }

        private void boostrapNajblizszejSredniejTest_Click(object sender, EventArgs e)
        {
            this.bootstrapNabjlizszejSredniejWynik.Text = new Bootstrap<KlasyfikatorNajblizszejSredniej>(this._wybraneCechy, 1)
                                                              .Test(int.Parse(this.bootstrapNajblizszejSredniejIle.Text))
                                                              .ToString(CultureInfo.InvariantCulture) + '%';
        }
    }
}
