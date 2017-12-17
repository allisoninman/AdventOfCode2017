using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC
{
    class Program
    {
        static void Main(string[] args)
        {
            var dayOneInput = "892195969991735837915273868729548694237967495115412399373194562526947585337233793568278265279199883197167634791293177986152566236718332617536487236879747167999983363832257912445756887314879229925864477761357139855548522513798899853896612387146687716264599943289416326727256525173953861534244979466587895429399159924916364476319573895566795393368411672387263615582128377676293612892723762237191146714286233543514411813323197995953854871628225358543514157867372265718724276911699514971458844849349726276329135118243155698271218844347387457343656446381799296893222256198484465873714311777937421161581798189554141474236239447612421883232173914183732126332838194648583472419154369952477422666389517569944428464617457124369349242479612422673241361777576466946622932243728551273284837934497511114334421486262244982914734452113946361245377351849815584855691778894798219822463298387771923329337634394654439458564233259451453345316753241438267739439225497515276522424441532462541528195782818326918562247278496495764435386667383577543385186827269732261223156824351164841648424564925198783625721396988984481558391866483955533972212164693898955412719161648411279149413443192896864258215498543827458438871355879336892721675937111952479183496982825163456282747678364612135596373533447719867384667516572262124225585623974278833981365494628646614588114147473559138853453189448624976774641922469183942857695986376428944876851497914443873513862319484181787593572987444669767939526294424531262999564948571142342741129862311311313166798363442745792896227642881893134498151552326647933689596516859342242244584714818773791567187322217164347852843751875979415198165627534263527828414549217234322361937785185174993256753483876378332521824515977173397535784236923629636713469151526399149548322849831431526219478653861754364155275865511643923249858589466142474763778413826829226663398467569555747267195129525138917561785436449855933951538973995881954521124753369223898312843734771532342383282987422334196585128526526324291777689689492346231786335851551413876834969878";
            Console.WriteLine("Day 1, Challenge 1: " + Day1.challenge1(dayOneInput));
            Console.WriteLine("Day 1, Challenge 2: " + Day1.challenge2(dayOneInput));

            var dayTwoInput = Utility.getFileLines("day2Input.txt");
            Console.WriteLine("Day 2, Challenge 1: " + Day2.challenge1(dayTwoInput));
            Console.WriteLine("Day 2, Challenge 2: " + Day2.challenge2(dayTwoInput));

            var dayFourInput = Utility.getFileLines("day4Input.txt");
            Console.WriteLine("Day 4, Challenge 1: " + Day4.challenge1(dayFourInput));
            Console.WriteLine("Day 4, Challenge 2: " + Day4.challenge2(dayFourInput));

            var dayFiveInput = Utility.getFileLines("day5Input.txt");
            Console.WriteLine("Day 5, Challenge 1: " + Day5.challenge1(dayFiveInput));
            Console.WriteLine("Day 5, Challenge 2: " + Day5.challenge2(dayFiveInput));

            var daySixInput = Utility.getFileLines("day6Input.txt");
            Console.WriteLine("Day 6, Challenge 1: " + Day6.challenge1(daySixInput));
            Console.WriteLine("Day 6, Challenge 2: " + Day6.challenge2(daySixInput));

            var daySevenInput = Utility.getFileLines("day7Input.txt");
            Console.WriteLine("Day 7, Challenge 1: " + Day7.challenge1(daySevenInput));
            Console.WriteLine("Day 7, Challenge 2: " + Day7.challenge2(daySevenInput));

            var dayEightInput = Utility.getFileLines("day8Input.txt");
            Console.WriteLine("Day 8, Challenge 1: " + Day8.challenge1(dayEightInput));
            Console.WriteLine("Day 8, Challenge 2: " + Day8.challenge2(dayEightInput));
            
            var dayNineInput = Utility.getFileLines("day9Input.txt");
            Console.WriteLine("Day 9, Challenge 1: " + Day9.challenge1(dayNineInput[0]));
            Console.WriteLine("Day 9, Challenge 2: " + Day9.challenge2(dayNineInput[0]));
            
            var dayTenInput = Utility.getFileLines("day10Input.txt");
            Console.WriteLine("Day 10, Challenge 1: " + Day10.challenge1(dayTenInput));
            Console.WriteLine("Day 10, Challenge 2: " + Day10.challenge2(dayTenInput));

            var dayElevenInput = Utility.getFileLines("day11Input.txt");
            Console.WriteLine("Day 11, Challenge 1: " + Day11.challenge1(dayElevenInput[0]));
            Console.WriteLine("Day 11, Challenge 2: " + Day11.challenge2(dayElevenInput[0]));

            var dayTwelveInput = Utility.getFileLines("day12Input.txt");
            Console.WriteLine("Day 12, Challenge 1: " + Day12.challenge1(dayTwelveInput));
            Console.WriteLine("Day 12, Challenge 2: " + Day12.challenge2(dayTwelveInput));

            var dayThirteenInput = Utility.getFileLines("day13Input.txt");
            Console.WriteLine("Day 13, Challenge 1: " + Day13.challenge1(dayThirteenInput));
            Console.WriteLine("Day 13, Challenge 2: " + Day13.challenge2(dayThirteenInput));

            var dayFourteenInput = "stpzcrnm";
            Console.WriteLine("Day 14, Challenge 1: " + Day14.challenge1(dayFourteenInput));
            Console.WriteLine("Day 14, Challenge 2: " + Day14.challenge2(dayFourteenInput));

            Console.WriteLine("Day 15, Challenge 1: " + Day15.challenge1(289, 629));
            Console.WriteLine("Day 15, Challenge 2: " + Day15.challenge2(289, 629));

            var daySixteenInput = Utility.getFileLines("day16Input.txt");
            Console.WriteLine("Day 16, Challenge 1: " + Day16.challenge1(daySixteenInput[0]));
            Console.WriteLine("Day 16, Challenge 2: " + Day16.challenge2(daySixteenInput[0]));

            var daySeventeenInput = 371;
            Console.WriteLine("Day 17, Challenge 1: " + Day17.challenge1(daySeventeenInput));
            Console.WriteLine("Day 17, Challenge 2: " + Day17.challenge2(daySeventeenInput));

            Console.Read();

        }
    }
}
