using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace _2B_3;
public class Model
{
    readonly List<Scene> _script;
    readonly List<Process> _processes;
    readonly Timer _timer;
    Scene _scene_c;
    float _mile;
    int _token;
    int _count;

    Form1.Nexus _form1;

    public Nexus GetNexus() => new(this, _token = Random.Shared.Next());
    public Form1.Nexus View { set =>  _form1 = value; }

    public Model()
    {
        _script = [];
        _processes = [];
        _timer = new() 
        {
            Interval = 1000,
        };
        _timer.Tick += (_, _) =>
        {
            _form1.Counter = ++_count;
        };

        InitScript();
    }

    public void SetState(int token, int stateNumber)
    {
        if (_token != token) throw new ArgumentException();
        if (stateNumber < 0) stateNumber = 0;
        if (stateNumber >= _script.Count) Environment.Exit(0);
        if (_script[stateNumber] == _scene_c) return;

        var lpm = (1976.0 + 2340.0) / _count;

        _scene_c.OnExit?.Invoke();
        _scene_c = _script[stateNumber];
        _mile = Single.IsNaN(_scene_c.Mile) ? _mile : _scene_c.Mile;
        _form1.Message = _scene_c.Message;
        _form1.LeftText = _scene_c.LeftText + (_mile >= 0.9f ? $"\nおまけ：あなたの筆記スピードは {lpm:.00} 打鍵毎秒です。{lpm switch
        {
            > 7 => "SSSランク。！？！？！？",
            > 6 => "SSランク。怪物級！",
            > 5 => "Sランク。天才！",
            > 4.2 => "Aランク。素晴らしい！",
            > 3.2 => "Bランク。十分通用する。",
            > 2.5 => "Cランク。ちょっと苦手かも。",
            _ => "Dランク。頑張ろう！",
        }}" : String.Empty);
        _form1.RightText = _scene_c.RightText;
        _form1.Pausable = _scene_c.Pausable;
        _timer.Enabled = _scene_c.EnableTimer;
        _scene_c.OnEnter?.Invoke();
    }

    public void ReceiveText(string text)
    {
        _form1.Mile = _mile + (float)text.Length / _scene_c.LeftText.Length * 0.4f;
    }

    private record struct Scene(string Message, float Mile = float.NaN, string LeftText = "", string RightText = "", bool Pausable = false, Action? OnEnter = null, Action? OnExit = null, bool EnableTimer = false)
    {

    }

    public struct Nexus
    {
        readonly Model _cell;
        readonly int _token;
        int _state;

        public Nexus(Model cell, int token)
        {
            _cell = cell;
            _token = token;
            _state = -1;
        }

        public int State
        {
            get => _state;
            set
            {
                if (_state == value) return;
                _state = value;
                _cell.SetState(_token, _state);
            }
        }

        public string Text
        {
            set
            {
                _cell.ReceiveText(value);
            }
        }

        public bool Running
        {
            set
            {
                _cell._timer.Enabled = value;
            }
        }

        public void Dispose()
        {
            foreach(var p in _cell._processes)
            {
                //if (!p.HasExited)
                {
                    p.CloseMainWindow();
                    p.Close();
                    p.Dispose();
                }
            }
        }
    }

    void InitScript()
    {
        const string DUMP = "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n";
        const string LT = "ここに本文が表示されます。\n好きなフォントを設定できます。";
        const string RT = "ここに入力してください。（まだ入力しないでください）";
        const string TXT1 = """
            宿題（しゅくだい、英：homework, homework assignment）は、学校教育等において、教師が授業時間外に児童・生徒・学生に課する自己学習の課題を指す。
        
            広く一般に、学校等で教師が児童・生徒・学生に課す自己学習の課題全般を宿題と呼ぶ。宿題は日ごろの授業中に課されることもあれば、定期考査の前後や、あるいは長期休業（夏休みや冬休みなど）中の課題として課されることもある。初等教育における宿題の種類としては以下のようなものがある。
            * 自主学習などの自由課題
            * プリント教材、教科書などの練習問題
            * 問題集などによる問題演習
            * 作文・レポート・作品などを教師に提出する。教師は提出された宿題の内容を点検する。宿題の内容により、検印を押したり、添削を行った上で児童らへ返却することもある。
        
            宿題を出す意図は学校や教師によって様々である。多くは授業の理解度の確認目的であり、また児童・生徒・学生の意識調査目的である。プリントや教材による問題演習は前者にあたり、作文や感想文は後者にあたる。
        
            日本の初等から中等教育では、与えられた学習課題に取り組み解答する宿題（ワークシートや問題集など）、また自己の意見・考えをまとめるもの（作文や新聞作りなど）が多い。中等～高等教育では、自らが学習・研究した内容などをまとめ、小論文の形式にするレポート形式の宿題が多くなる。
        
            宿題の多くは提出期限があり、その期限内に指定された内容を学習して提出することが求められる。また、内容が不十分であれば再提出を求められることや、期限内に提出できなければ成績から減点されることがある。
        
            こうした「提出期限を遵守する」また「守ることができなければペナルティが課される」という宿題のルールは、会社等の一部の業務における「与えられた仕事を期限までに完成する」ルールと非常に親和性がある。そのため宿題を学校教育における社会訓練の一環として重要視する人も多く、宿題を期日までに提出できなかった生徒には教師が個別で指導をする場合がある。
            """;
        const string TXT2 = """
            Homework is a set of tasks assigned to students by their teachers to be completed at home. Common homework assignments may include required reading, a writing or typing project, mathematical exercises to be completed, information to be reviewed before a test, or other skills to be practiced.
        
            The benefits of homework are debated. Generally speaking, homework does not improve academic performance among young children. Homework may improve academic skills among older students, especially lower-achieving students. It is also believed it creates stress on students and parents, and reduces the amount of time that students can spend in other important activities. Hence, emphasis should be not on how long students spend on the homework but on what they gain through the practice. It can be useful to help students develop their self-regulation skills.

            Cultivating self-regulation skills is vital for individuals to become lifelong learners and sustain their growth over time. While developing these skills may require dedication and patience, the long-term benefits can make it worthwhile to some.

            Homework research dates back to the early 1900s. However, no consensus exists on the general effectiveness on homework. Results of homework studies vary based on multiple factors, such as the age group of those studied and the measure of academic performance.

            Younger students who spend more time on homework generally have slightly worse, or the same academic performance, as those who spend less time on homework. Homework has not been shown to improve academic achievements for grade school students. Proponents claim that assigning homework to young children helps them learn good study habits. No research has ever been conducted to determine whether this claim has any merit.

            Among teenagers, students who spend more time on homework generally have higher grades, and higher test scores than students who spend less time on homework. Large amounts of homework cause students' academic performance to worsen, even among older students. Students who are assigned homework in middle and high school score somewhat better on standardized tests, but the students who have more than 90 minutes of homework a day in middle school or more than two hours in high school score worse.
            """;

        var f = (Random.Shared.Next() & 1) == 0;

        var a1 = (Scene[])[
            new("""
                実験へのご協力ありがとうございます。
                [すすむ]を押すと次へ進みます。（以降も同様です）
                """),
            new("""
                本実験は日本語の文章と英語の文章における、誤字訂正機能の
                有効性を検証する目的で行われています。
                """),
            new("""
                被験者の方には、日常のタイピングの中でどのようなタイプミスを犯し
                どのような方法で訂正を行っているのかを実演していただきます。
                """),
            new("""
                実際にやっていただくことは以下の三点です。（順序は変わることがあります）
                1. 日本語の文章を転記します。
                2. 英語の文章を転記します。
                3. 結果を送信します。
                """),
            new("""
                実験には三十分程掛かりますが、個人差があります。
                途中で早く終わらせたいと感じた場合は、スキップすることができます。
                但し、日本語と英語のどちらか片方しか行わないことは避けてください。
                """),
            new("""
                本実験における禁止事項は以下の二点です。
                * コピーあるいはペーストを≪行わないでください≫。
                * 配布されたフォルダの中身を直接改変≪しないでください≫。
                """),
            new("""
                実験中、被験者の方の入力データが記録されます。
                得られたデータは本研究員が自由に使用することができます。
                """),
            new("""
                以上のことに同意いただけましたら、
                [すすむ]を押してください。
                """, 0.05f),
            new("""
                ご協力ありがとうございます。
                早速実験に移りましょう。（まだ始まりません）
                """),
            new("""
                一度環境のテストを行います。
                [すすむ]を押して、警告が表示された場合は[詳細を確認]して[実行]してください。
                """),
            new("""
                警告が表示された場合は許可してください。
                許可できた、或いは何も表示されなかった場合は本番へ移ります。
                """, 0.1f, OnEnter: StartLog, OnExit: StopLog),
            ];
        var a2 = (Scene[])[
            new("""
                /// 日本語文を転記する課題 ///
                全角半角誤字脱字に注意しながら右のボックスに文章を転記してください。
                普段通りの入力方法で、急がず行ってください。
                [すすむ]を押すと始まります。≪実験中は他のソフトに対しても一切操作をしないでください≫。
                """, LeftText: LT, RightText: RT),
            new("""
                /// 日本語文を転記する課題 ///
                全角半角誤字脱字に注意しながら右のボックスに文章を転記してください。
                普段通りの入力方法で、急がず行ってください。
                計測中です。≪他に何もしないでください≫。[すすむ]を押すと完了します。(ソース:^1)
                """, LeftText: TXT1, RightText: DUMP, Pausable: true, OnEnter: StartLog, OnExit: StopLog, EnableTimer: true)
            ];
        var a3 = (Scene[])[
            new("""
                計測を終了しました。ありがとうございます。
                [もどる]を押すと最初からやり直すことができます。
                次の実験に移りましょう。（まだ始まりません）
                """, 0.5f)
            ];
        var a4 = (Scene[])[
            new("""
                /// 英語文を転記する課題 ///
                半角英数字で右のボックスに文章を転記してください。
                普段通りの入力方法で、急がず行ってください。
                [すすむ]を押すと始まります。≪実験中は他のソフトに対しても一切操作をしないでください≫。
                """, LeftText: LT, RightText: RT),
            new("""
                /// 英語文を転記する課題 ///
                半角英数字で右のボックスに文章を転記してください。
                普段通りの入力方法で、急がず行ってください。
                計測中です。≪他に何もしないでください≫。[すすむ]を押すと完了します。(ソース:^2)
                """, LeftText: TXT2, RightText: DUMP, Pausable: true, OnEnter: StartLog, OnExit: StopLog, EnableTimer: true)
            ];
        var a5 = (Scene[])[
            new("""
                計測を終了しました。お疲れさまでした。
                [もどる]を押すと最初からやり直すことができます。
                結果の送信に移りましょう。
                """, 0.9f, OnEnter: () => 
                {
                    _processes.Add(Process.Start("MakeResult.bat", $"{DateTime.Now.Year}_{DateTime.Now.Month:00}_{DateTime.Now.Day:00}")); 
                }),
            new("""
                /// 結果の送信 ///
                実行ファイル(.exe)と同じフォルダにRESULTファイルがあります。
                このファイルを添付し、題名を「実験結果」とし、行った人がわかるような
                内容を記載し`postmaster@niiinonno.sakura.ne.jp`へ送信してください。
                """),
            new("""
                /// 結果の送信 ///
                折り返し返信致しますので、到着の確認が取れるまで
                RESULTファイルは保管しておいてください。
                """, 1f),
            new("""
                以上で終了になります。ご協力に改めて感謝申し上げます。
                感想・ご意見は`postmaster@niiinonno.sakura.ne.jp`へお願いします。
                Discord等で本研究員と連絡が取れる場合はそちらを使ってもかまいません。
                """),
            new("""
                [すすむ]を押してソフトを終了します。
                """),
        ];
        var a6 = (Scene[])[a2[0] with { Mile = 0.5f }, a2[1] with { Mile = 0.5f }];
        var a7 = (Scene[])[a4[0] with { Mile = 0.1f }, a4[1] with { Mile = 0.1f }];

        _script.AddRange(a1);
        if (f)
        {
            _script.AddRange(a2);
            _script.AddRange(a3);
            _script.AddRange(a4);
        }
        else
        {
            _script.AddRange(a7);
            _script.AddRange(a3);
            _script.AddRange(a6);
        }
        _script.AddRange(a5);
    }

    void StartLog()
    {
        var ps = new ProcessStartInfo()
        {
            FileName = "key",
            CreateNoWindow
#if DEBUG
                = false,
#else
                = true,
#endif
        };
        if (Process.Start(ps) is { } p) _processes.Add(p);
    }

    void StopLog()
    {
        try
        {
            foreach (var p in _processes.ToArray())
            {
                if (!p.HasExited && p.ProcessName != "key") continue;
            
                p.CloseMainWindow();
                p.Dispose();
                _processes.Remove(p);
            }
        }
        catch (Exception e)
        {
            DialogResult result = MessageBox.Show(e.ToString(),
                "異常",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
            Environment.Exit(e.GetHashCode());
        }
    }
}
