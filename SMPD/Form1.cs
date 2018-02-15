using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SMPD.FeatureSelection;
using System.Diagnostics;
using System.Globalization;
using Accord.Math;
using SMPD.Classifiers;
using SMPD.Tests;

namespace SMPD
{
    public partial class Form1 : Form
    {
        private List<MapleSample> _mapleSamples = new MapleOakExampleFileReader().ReadSamples().ToList();
        private List<double[]> _acer;
        private List<double[]> _quercus;
        private int _featureCount = 1;

        public Form1()
        {
            InitializeComponent();
            _acer = _mapleSamples.Where(x => x.label.StartsWith("Acer")).SelectMany(x => x.samples).ToList();
            _quercus = _mapleSamples.Where(x => x.label.StartsWith("Quercus")).SelectMany(x => x.samples).ToList();
        }



        private async void fisher_click(object sender, EventArgs e)
        {
            this._featureCount = int.Parse(this.maskedTextBox1.Text);
            IProgress<(int, int)> progress = new Progress<(int, int)>(value =>
              {
                  this.progressBar1.Value = value.Item1; this.progressBar1.Maximum = value.Item2;
              });
            this.button1.Enabled = false;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = await Task.Factory.StartNew(() => new FisherFeatureSelector(_featureCount, progress).SelectFeatures(_acer, _quercus));
            stopwatch.Stop();
            this._mapleSamples = _mapleSamples.Select(sample => new MapleSample
            {
                label = sample.label,
                samples = sample.samples.Where((t, i) => result.Features.Contains(i)).ToArray().ToList().ToArray()
            }).ToList();
        
            this._acer = _acer.Select(sample => sample.Where((t, i) => result.Features.Contains(i)).ToArray()).ToList();
            this._quercus = _quercus.Select(sample => sample.Where((t, i) => result.Features.Contains(i)).ToArray()).ToList();
            this.button1.Enabled = true;
            this.textBox1.Text = result.Features.Aggregate(string.Empty, (s, i) => s + ',' + i.ToString());
            this.textBox5.Text = result.CriterionValue.ToString("G");
            this.textBox2.Text = stopwatch.ElapsedMilliseconds.ToString("F") + @" ms";
        }

    private void progressBar1_Click(object sender, EventArgs e)
    {

    }

    private void label2_Click(object sender, EventArgs e)
    {

    }

    private void textBox2_TextChanged(object sender, EventArgs e)
    {

    }

    private async void sfs_click(object sender, EventArgs e)
    {
        this._featureCount = int.Parse(this.maskedTextBox1.Text);

        IProgress<(int, int)> progress = new Progress<(int, int)>(value =>
        {
            this.progressBar2.Value = value.Item1; this.progressBar2.Maximum = value.Item2;
        });
        this.button2.Enabled = false;
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        var result = await Task.Factory.StartNew(
            () => new SequentialForwardSelector(
                _featureCount, progress, (enumerable, enumerable1)
                    => new FisherFeatureSelector(_featureCount, progress)
                        .SelectFeatures(enumerable, enumerable1)).SelectFeatures(_acer, _quercus));
        stopwatch.Stop();
        this.button2.Enabled = true;
        this.textBox4.Text = result.Features.Aggregate(string.Empty, (s, i) => s + i.ToString() + ',');
        this.textBox6.Text = result.CriterionValue.ToString("G");
        this.textBox3.Text = stopwatch.ElapsedMilliseconds.ToString("F") + @" ms";
    }

    private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
    {

    }

    private NNClassifier nnClassifier;
    private int _nnEndIndexA;
    private int _nnEndIndexQ;


    private void button3_Click(object sender, EventArgs e)
    {
        var percent = double.Parse(this.maskedTextBox2.Text) / 100;
        _nnEndIndexA = Convert.ToInt32(this._acer.Count * percent);
        _nnEndIndexQ = Convert.ToInt32(this._quercus.Count * percent);



        var inputs = this._acer.GetRange(0, _nnEndIndexA).Concat(this._quercus.GetRange(0, _nnEndIndexQ)).ToArray();
        var outputs = this._acer.GetRange(0, _nnEndIndexA).Select(_ => 0)
            .Concat(this._quercus.GetRange(0, _nnEndIndexQ).Select(_ => 1)).ToArray();

        this.nnClassifier = new NNClassifier(2, inputs, outputs, Distance.Euclidean);
    }

    private void button4_Click(object sender, EventArgs e)
    {
        var inputs = this._acer.GetRange(_nnEndIndexA, this._acer.Count - _nnEndIndexA).Concat(this._quercus.GetRange(_nnEndIndexQ, this._quercus.Count - _nnEndIndexQ)).ToArray();
        var outputs = this._acer.GetRange(_nnEndIndexA, this._acer.Count - _nnEndIndexA).Select(_ => 0)
            .Concat(this._quercus.GetRange(_nnEndIndexQ, this._quercus.Count - _nnEndIndexQ).Select(_ => 1)).ToArray();
        var results = inputs.Select(x => this.nnClassifier.Execute(x)).ToArray();

        var accuracy = (double)outputs.Where((t, i) => t == results[i]).Count() / (double)outputs.Length;
        textBox7.Text = accuracy * 100 + "%";
    }

    private KnnClassifier knnClassifier;
    private int _nnEndIndexAk;
    private int _nnEndIndexQk;
    private int _nnEndIndexAnM;
    private int _nnEndIndexQnM;
    private NearestMeanClassifier nmClassifier;


    private void button6_Click(object sender, EventArgs e)
    {
        var percent = double.Parse(this.maskedTextBox3.Text) / 100;
        _nnEndIndexAk = Convert.ToInt32(this._acer.Count * percent);
        _nnEndIndexQk = Convert.ToInt32(this._quercus.Count * percent);
        var k = int.Parse(this.textBox9.Text);


        var inputs = this._acer.GetRange(0, _nnEndIndexAk).Concat(this._quercus.GetRange(0, _nnEndIndexQk)).ToArray();
        var outputs = this._acer.GetRange(0, _nnEndIndexAk).Select(_ => 0)
            .Concat(this._quercus.GetRange(0, _nnEndIndexQk).Select(_ => 1)).ToArray();

        this.knnClassifier = new KnnClassifier(k, 2, inputs, outputs, Distance.Euclidean);
    }

    private void button5_Click(object sender, EventArgs e)
    {
        var inputs = this._acer.GetRange(_nnEndIndexAk, this._acer.Count - _nnEndIndexAk).Concat(this._quercus.GetRange(_nnEndIndexQk, this._quercus.Count - _nnEndIndexQk)).ToArray();
        var outputs = this._acer.GetRange(_nnEndIndexAk, this._acer.Count - _nnEndIndexAk).Select(_ => 0)
            .Concat(this._quercus.GetRange(_nnEndIndexQk, this._quercus.Count - _nnEndIndexQk).Select(_ => 1)).ToArray();
        var results = inputs.Select(x => this.knnClassifier.Execute(x)).ToArray();

        var accuracy = (double)outputs.Where((t, i) => t == results[i]).Count() / (double)outputs.Length;
        textBox8.Text = accuracy * 100 + "%";
    }

    private void nMeanTrain_Click(object sender, EventArgs e)
    {
        var percent = double.Parse(this.nMSamplePercent.Text) / 100;
        _nnEndIndexAnM = Convert.ToInt32(this._acer.Count * percent);
        _nnEndIndexQnM = Convert.ToInt32(this._quercus.Count * percent);


        var inputs = this._acer.GetRange(0, _nnEndIndexAnM).Concat(this._quercus.GetRange(0, _nnEndIndexQnM)).ToArray();
        var outputs = this._acer.GetRange(0, _nnEndIndexAnM).Select(_ => 0)
            .Concat(this._quercus.GetRange(0, _nnEndIndexQnM).Select(_ => 1)).ToArray();

        this.nmClassifier = new NearestMeanClassifier(2, inputs, outputs, Distance.Euclidean);

    }

    private void nMeanExecute_Click(object sender, EventArgs e)
    {
        var inputs = this._acer.GetRange(_nnEndIndexAnM, this._acer.Count - _nnEndIndexAnM).Concat(this._quercus.GetRange(_nnEndIndexQnM, this._quercus.Count - _nnEndIndexQnM)).ToArray();
        var outputs = this._acer.GetRange(_nnEndIndexAnM, this._acer.Count - _nnEndIndexAnM).Select(_ => 0)
            .Concat(this._quercus.GetRange(_nnEndIndexQnM, this._quercus.Count - _nnEndIndexQnM).Select(_ => 1)).ToArray();
        var results = inputs.Select(x => this.nmClassifier.Execute(x)).ToArray();

        var accuracy = (double)outputs.Where((t, i) => t == results[i]).Count() / (double)outputs.Length;
        nMeanResult.Text = accuracy * 100 + "%";
    }

    private void crossvalidatebutton_Click(object sender, EventArgs e)
    {
        var selected = this.crossvalidatecombo.SelectedItem as string;
        switch (selected)
        {
            case "kNN":
                this.crossvalidateresult.Text = new Crossvalidation<KnnClassifier>(this._mapleSamples, int.Parse(this.textBox9.Text)).Test(int.Parse(this.crossvalidationparts.Text)).ToString(CultureInfo.InvariantCulture) + '%';
                break;
            case "NN":
                this.crossvalidateresult.Text = new Crossvalidation<NNClassifier>(this._mapleSamples, 1).Test(int.Parse(this.crossvalidationparts.Text)).ToString(CultureInfo.InvariantCulture) + '%';
                break;
            case "NM":
                this.crossvalidateresult.Text = new Crossvalidation<NearestMeanClassifier>(this._mapleSamples, 1).Test(int.Parse(this.crossvalidationparts.Text)).ToString(CultureInfo.InvariantCulture) + '%';
                break;
        }
    }

    private void bootsrapttest_Click(object sender, EventArgs e)
    {
        var selected = this.bootstrapcombo.SelectedItem as string;
        switch (selected)
        {
            case "kNN":
                this.bootstrapresult.Text = new Bootstrap<KnnClassifier>(this._mapleSamples, int.Parse(this.textBox9.Text)).Test(int.Parse(this.bootsrapcount.Text)).ToString(CultureInfo.InvariantCulture) + '%';
                break;
            case "NN":
                this.bootstrapresult.Text = new Bootstrap<NNClassifier>(this._mapleSamples, 1).Test(int.Parse(this.bootsrapcount.Text)).ToString(CultureInfo.InvariantCulture) + '%';
                break;
            case "NM":
                this.bootstrapresult.Text = new Bootstrap<NearestMeanClassifier>(this._mapleSamples, 1).Test(int.Parse(this.bootsrapcount.Text)).ToString(CultureInfo.InvariantCulture) + '%';
                break;
        }
    }
}
}
