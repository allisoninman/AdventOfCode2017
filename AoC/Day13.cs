using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AoC
{
    class Day13
    {
        public static int challenge1(List<string> input)
        {
            var pairs = new Dictionary<int, int>();
            var scannerPos = new Dictionary<int, int>();
            var scannerDirs = new Dictionary<int, string>();
            for(var i = 0; i < input.Count; i++)
            {
                var line = input[i].Split(' ');
                pairs.Add(int.Parse(line[0].Replace(":", "")), int.Parse(line[1]));
                scannerPos.Add(int.Parse(line[0].Replace(":", "")), 0);
                scannerDirs.Add(int.Parse(line[0].Replace(":", "")), "down");
            }

            var severity = 0;

            for(var i = 0; i <= 98; i++)
            {
                if (pairs.ContainsKey(i) && scannerPos[i] == 0)
                {
                    severity += pairs[i] * i;
                }
                foreach(var key in pairs.Keys)
                {
                    if(scannerDirs[key] == "down" && scannerPos[key] < pairs[key] - 1)
                    {
                        scannerPos[key]++;
                    } else if(scannerDirs[key] == "down" && scannerPos[key] == pairs[key] - 1)
                    {
                        scannerDirs[key] = "up";
                        scannerPos[key]--;
                    } else if(scannerDirs[key] == "up" && scannerPos[key] == 0)
                    {
                        scannerDirs[key] = "down";
                        scannerPos[key]++;
                    }
                    else
                    {
                        scannerPos[key]--;
                    }
                }
            }
            return severity;
        }

        public static int challenge2(List<string> input)
        {
            var pairs = new Dictionary<int, int>();
            var scannerPos = new Dictionary<int, int>();
            var scannerDirs = new Dictionary<int, string>();
            for (var i = 0; i < input.Count; i++)
            {
                var line = input[i].Split(' ');
                pairs.Add(int.Parse(line[0].Replace(":", "")), int.Parse(line[1]));
                scannerPos.Add(int.Parse(line[0].Replace(":", "")), 0);
                scannerDirs.Add(int.Parse(line[0].Replace(":", "")), "down");
            }

            var severity = -1;
            var delay = 0;
            var lastDelayPositions = new Dictionary<int, int>(scannerPos);
            var lastDelayDirs = new Dictionary<int, string>(scannerDirs);
            while(severity != 0)
            {
                severity = 0;
                delay++;

                //make step
                foreach (var key in pairs.Keys)
                {
                    if (lastDelayDirs[key] == "down" && lastDelayPositions[key] < pairs[key] - 1)
                    {
                        lastDelayPositions[key]++;
                    }
                    else if (lastDelayDirs[key] == "down" && lastDelayPositions[key] == pairs[key] - 1)
                    {
                        lastDelayDirs[key] = "up";
                        lastDelayPositions[key]--;
                    }
                    else if (lastDelayDirs[key] == "up" && lastDelayPositions[key] == 0)
                    {
                        lastDelayDirs[key] = "down";
                        lastDelayPositions[key]++;
                    }
                    else
                    {
                        lastDelayPositions[key]--;
                    }
                }

                scannerPos = new Dictionary<int, int>(lastDelayPositions);
                scannerDirs = new Dictionary<int, string>(lastDelayDirs);

                for (var i = 0; i <= 98; i++)
                {
                    if (pairs.ContainsKey(i) && scannerPos[i] == 0)
                    {
                        severity = 1;
                        break;
                    }
                    foreach (var key in pairs.Keys)
                    {
                        if (scannerDirs[key] == "down" && scannerPos[key] < pairs[key] - 1)
                        {
                            scannerPos[key]++;
                        }
                        else if (scannerDirs[key] == "down" && scannerPos[key] == pairs[key] - 1)
                        {
                            scannerDirs[key] = "up";
                            scannerPos[key]--;
                        }
                        else if (scannerDirs[key] == "up" && scannerPos[key] == 0)
                        {
                            scannerDirs[key] = "down";
                            scannerPos[key]++;
                        }
                        else
                        {
                            scannerPos[key]--;
                        }
                    }
                }
            }
            return delay;
        }
    }
}
