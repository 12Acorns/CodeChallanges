using CodeChallanges.CC_FIndMissingN;
using CodeChallanges;
using CodeChallanges.CC_IsPalindrome;

//string[] input =
//[
//	"ncorlzqinttjbrxrghpxxtivqrthctolvclztnpmmwqxmojygwffwgyjomxqwmmpntzlcvlotchqvitxxphgrxrbjttniqzlrocn",
//	"czjmlygpoutxeezqlnytoyjedrlrsyerfqkkqfreyslrdejyotynlqzeextuopgylmjzct",
//	"rvhzlycppcylzhvt",
//	"qejoeqxkrtwargzrhhrzgrawkxqeojeq",
//	"bzesllutywtchqjsyyffyysjqhctwrtytullsezb",
//	"upzeadmuemiqrvutwhgpyrnbhyxbblrvwzhddgqriykkyirqgddhzwvrlbbxyhbnypghwtuvrqimeumdaezpu",
//	"gobxxiyzfisqgegwojffjowgegqsirfzyixxbog",
//	"rliggaodtaoiuwxlzwxwiqcglgrrlheyvwmohrrhomwvyehlrglgcqiwxwzlxwuioatdoaggilr",
//	"qvdoszyivpamkndtrdglncvembfpxaxclayyalcxaxpfbmevcnlgdtdnkmapviyzsodvq",
//	"epkjwrcuyvmtjjtmvyucrwrjkpe",
//	"rysnbeksarwyujufhonmchdtilhqcwasegrwrmsgqldrrluffulrrdlqgsmwrgesawcqhlitdhcmnohfujuywraskebnsyr",
//	"sohdqlslkyntbdmmeczpcpvvxfkwkkwkfxvvpcpzcemmdbtnyklslqdhosr",
//	"lhcfbeuxpqwliarmawblxnggnxlbwamailwqpxuebfchl",
//	"gqmzhjurwqddqwrurjhzmqg",
//	"gyjnwxwplrlpwxwnjyg",
//	"neaqrqwsigdfbqntcarifwtsvdybfwawkkwawfbydvstwfiactnqbfdgiswqrqaen",
//	"asggdirbcjyjapwgvnorserresonvgwpajyjcbridggsa",
//	"mfeqmyigusuaczbmicnddmlooyelyjzrvyzzyvzjyleyoolmddncimbzcausugiymqefm",
//	"xnqtyezridyvqqvydizeytqnx",
//	"cpnewohthbnaxuyrececlfflceceyuxanbhthowenpc",
//	"rrsdlqigeuyyuergiqldsrr",
//	"gcrpbmyyakfpermkkmrepfkayymbpcg",
//	"rfodxgwjjwgxdof",
//	"otbmxxgnrdwwdngxxmbto",
//	"btchzusuxrrqrtipcpisddsipcpitrqrxusuzhctb",
//	"efommicesffsecimmorfe",
//	"dcdzqlmbcudsewwjnfqmpinmtlzyaezrspnnnwdgnxqfrphjkiikjhprfqxngdwnnnpszeayzltmnipmqfnjwwesducbmlqzdcd",
//	"cvprormpduxwmpkkpmwxudpmropvc",
//	"narfvfcyujctkooktrcjuycfvfran",
//	"zkryhffbimoxpudkftetrkrcyvzzlqxqccccqxqlzzvyckrtetfkdupxomibffhyrkz",
//	"azijtrjbgscofdzszulewlarnzcixvvxicznralweluzszdfocsgbjtjiza",
//	"aedgcwdnfyfuufyfndwcgrdea",
//	"rbfzjychpjjmqjtujpvjmddrcignwzlhunegngbfctqnnziiznnqtcfbgngenuhlzwngicddmjvpjutjqmjjphcyjzfbr",
//	"rcizbuurtkgtzhlnkdsoayyyyaosdknlhztgktuubzicr",
//	"npuqtgfkuqysawyrjexmjihjqjoqapftzztfpaqojqjhijmxejywasyqukfgtqupn",
//	"yowayakdcaxgcygrelelefcylmiwyvtevfncfoofcnfvetvywimrlycfelelergycgxacdkayawoy",
//	"hmxrxmh",
//	"ahptdgsadrtesbrpprbsetdasgdtpha",
//	"vazigxryftxjunoryekqqinqtkydafqmkrywqbgbaxssxabgbqwykmqfadyktqniqqkeyronujxtfyrxgizav",
//	"oisiwpsjxrzbihdxnrowwornxdhibzrrxjspwisio",
//	"ckwlbquurqblwkc",
//	"pvwsjikmiiprrzzxpnqriwurruwiqnpxzzrrpiimkijswvp",
//	"onpwkffkwpnro",
//	"bxprrbflnbfuycuckkcucyrufbnlfbrrpxb",
//	"rpfgdorhgjtvyzdfcoruveisuweqpueulsrviegvaozwwjzkolddlokzjwwzoavgeivrslueupqewusievuocfdzyvtjghrodgfpr",
//	"brgmqsrmvzqrsykcmzoxwecxcuoqvyxomfccfmoxyvqoucxcewxozmckysqzvmrsqmgrb",
//	"akxknfmtsyctwouwxxneqjpkagwcrpkvsgciuuewxnkrollorknxweuuicgsvkprrcwgakpjqenxxwuowtcystmfnkxka",
//	"xgxknjwrrjelsxmesvnyupercoehhspeepshheocepuynvsemxslejrrwjnkxgx",
//	"vunkbxgnditiuxrrhhbjfovvprlcxfwpvxzaxeegdggdrgeexazxvpwfxclrpvvofjbhhrrxuitidngxbknuv",
//	"qprlqabpqlnccnlqpbaqlrrpq",
//	"ljhquompqhhiypqkbkhaynrobckboklnkctlqkbzmoqvneenvqomzbkqltcknlkobkcbonyahkbkqpyihhqpmouqhjl",
//	"rricgxdozippizrodxgcirr",
//	"gejuhnrbzssrfyskkzolszgozxfzsyrmphfxaonnggnnoaxfhpmryszfxzogzslozkksyfrsszbnhujeg",
//	"gougfyghaefjkmtqjtvnrjcjychuxwvzqmkrkyuitbdqqrdbtiuykrkmqzvwxuhcyjcjrnvtjqtmkjfeahgyfguog",
//	"kqanehhcngqrxaaemnbukibhzggzhbikubnrmeaaxrqgnchhenaqk",
//	"knvvdyvobtbrdeohpjwzejyezqzdsccsdzqzeyjezwjphoedbtbovydvvnk",
//	"pcnbxamptzpqwwqpzrtpmaxbncp",
//	"ufbljucrbxinfcyqllqycfnixbcujlbfu",
//	"uxquklmfxkxqunnmqmqbiojtfysbnwrrdfqatpjpdnndpjptaqfrdrrwnbsyftjoibqmqmnnuqxkxfmlkuqxu",
//	"oncdsauhqdfrrnempifrwtkhhkrqnzwsxbdzhgipuqccqupighzdbxswznqrkhhktwrfipmenrfdqhuasdcno",
//	"ncazyscahuplmssmlpuhacrsyzacn",
//	"zlcxntvefvpjluvrdoerhxxugzxcdhsvidhcedlzkpgnztkxxktzngpkzldechdivshdcxzguxxheodrvuljpvfevtnxclz",
//	"jtmphpxoipubnlyxxiaemzprddrpzmeairxxylnbupioxphpmtj",
//	"defssrjksqaagvffvgaaqskjssfed",
//	"qamqaoomdpkeggekpdmooraqmaq",
//	"yvtqrqtvy",
//	"qemlerxexrrxbdccolrmhyhehheragkhjccjhkgaehhehyhmrloccdbxrrxrxrelmeq",
//	"awserfdoxdcsyzmnicfjwnidnspjhwwwwjpsndinwjfcinmzyscdxbodfreswa",
//	"tucgmnbegtfimofigtwwtgifomiftgoebnmgcutr",
//	"edbzthmkzzgztiizsqveflodnnqokwiaaiwkoqnndolffevqsziitzgzzkmhtzbe",
//	"urgawartcvacksdhcmnoyclilcyonmchddsmkcavctrawagru"
//];

//var expected = input.Select(x => new ExpectedResult<string, bool>(data: x, true)).ToArray();
//var f5 = new ArraySegment<ExpectedResult<string, bool>>(expected, 0, 5)
//	.Select(static x => new ExpectedResult<string, bool>(x.Data, false)).ToArray();

//var l5 = new ArraySegment<ExpectedResult<string, bool>>(expected, input.Length - 5, 5)
//	.Select(static x => new ExpectedResult<string, bool>(x.Data, false)).ToArray();

//var eSpan = expected.AsSpan();
//f5.CopyTo(eSpan[..5]);
//l5.CopyTo(eSpan[^5..]);

//Tester.Match<string, bool>(IsPalindrome.IsPalindromeBaseline, expected, (name, dataAndResult, actualResult) =>
//{
//	Console.WriteLine($"{name}({dataAndResult.Data})\nExpect '{dataAndResult.Result}'\nGot '{actualResult}'\n");
//});

//return;

Benchmarker.TryRegister<MissingNBenchmarker>();
Benchmarker.TryRegister<IsPalindromeBenchmarker>();

Benchmarker.TryRun<IsPalindromeBenchmarker>(out _);