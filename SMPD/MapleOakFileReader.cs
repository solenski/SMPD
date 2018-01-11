using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPD
{
    public struct MapleSample
    {
        public double[][] samples { get; set; }
        public string label { get; set; }
    }

    class MapleOakExampleFileReader
    {
        private const string path = "MapleOak.txt";

        public IEnumerable<MapleSample> ReadSamples()
        {
            return File.ReadAllLines(path).Select(x => x.Split(',')).Select(x1 => new
            {
                label = x1[0],
                samples = x1.Skip(1).Select(y => Convert.ToDouble(y, CultureInfo.InvariantCulture)).ToArray()
            }).GroupBy(x => x.label).Select(x =>
                new MapleSample { label = x.Key, samples = x.Select(y => y.samples.ToArray()).ToArray() });
        }
    }
}
