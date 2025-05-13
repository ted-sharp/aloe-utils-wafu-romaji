using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace Aloe.Utils.Wafu.Romaji;

/// <summary>
/// ひらがな・カタカナ文字列をローマ字（ヘボン式）に変換するユーティリティクラスです。
/// </summary>
public static class Romanizer
{
    // ── 拗音パターンを定義 ──
    /// <summary>きゃ</summary>
    private const string KYA = "きゃ";
    /// <summary>きゅ</summary>
    private const string KYU = "きゅ";
    /// <summary>きょ</summary>
    private const string KYO = "きょ";
    /// <summary>しゃ</summary>
    private const string SHA = "しゃ";
    /// <summary>しゅ</summary>
    private const string SHU = "しゅ";
    /// <summary>しょ</summary>
    private const string SHO = "しょ";
    /// <summary>ちゃ</summary>
    private const string CHA = "ちゃ";
    /// <summary>ちゅ</summary>
    private const string CHU = "ちゅ";
    /// <summary>ちょ</summary>
    private const string CHO = "ちょ";
    /// <summary>にゃ</summary>
    private const string NYA = "にゃ";
    /// <summary>にゅ</summary>
    private const string NYU = "にゅ";
    /// <summary>にょ</summary>
    private const string NYO = "にょ";
    /// <summary>ひゃ</summary>
    private const string HYA = "ひゃ";
    /// <summary>ひゅ</summary>
    private const string HYU = "ひゅ";
    /// <summary>ひょ</summary>
    private const string HYO = "ひょ";
    /// <summary>みゃ</summary>
    private const string MYA = "みゃ";
    /// <summary>みゅ</summary>
    private const string MYU = "みゅ";
    /// <summary>みょ</summary>
    private const string MYO = "みょ";
    /// <summary>りゃ</summary>
    private const string RYA = "りゃ";
    /// <summary>りゅ</summary>
    private const string RYU = "りゅ";
    /// <summary>りょ</summary>
    private const string RYO = "りょ";
    /// <summary>ぎゃ</summary>
    private const string GYA = "ぎゃ";
    /// <summary>ぎゅ</summary>
    private const string GYU = "ぎゅ";
    /// <summary>ぎょ</summary>
    private const string GYO = "ぎょ";
    /// <summary>じゃ</summary>
    private const string JA = "じゃ";
    /// <summary>じゅ</summary>
    private const string JU = "じゅ";
    /// <summary>じょ</summary>
    private const string JO = "じょ";
    /// <summary>びゃ</summary>
    private const string BYA = "びゃ";
    /// <summary>びゅ</summary>
    private const string BYU = "びゅ";
    /// <summary>びょ</summary>
    private const string BYO = "びょ";
    /// <summary>ぴゃ</summary>
    private const string PYA = "ぴゃ";
    /// <summary>ぴゅ</summary>
    private const string PYU = "ぴゅ";
    /// <summary>ぴょ</summary>
    private const string PYO = "ぴょ";

    /// <summary>
    /// ひらがな・カタカナ混在文字列をヘボン式ローマ字に変換して返します。
    /// </summary>
    /// <param name="input">変換対象の文字列</param>
    /// <returns>ローマ字文字列</returns>
    public static string Convert(ReadOnlySpan<char> input)
    {
        if (input.IsEmpty)
        {
            return String.Empty;
        }

        ValueStringBuilder vsb = new ValueStringBuilder(stackalloc char[256]);

        for (int i = 0; i < input.Length; i++)
        {
            // ■ カタカナ→ひらがな正規化
            char c0 = (input[i] >= 'ァ' && input[i] <= 'ヺ') ? (char)(input[i] - 0x60) : input[i];

            // ■ 拗音（二文字）チェック
            if (i + 1 < input.Length)
            {
                ReadOnlySpan<char> two = input.Slice(i, 2);
                if (two.SequenceEqual(KYA)) { vsb.Append("kya"); i++; continue; }
                if (two.SequenceEqual(KYU)) { vsb.Append("kyu"); i++; continue; }
                if (two.SequenceEqual(KYO)) { vsb.Append("kyo"); i++; continue; }
                if (two.SequenceEqual(SHA)) { vsb.Append("sha"); i++; continue; }
                if (two.SequenceEqual(SHU)) { vsb.Append("shu"); i++; continue; }
                if (two.SequenceEqual(SHO)) { vsb.Append("sho"); i++; continue; }
                if (two.SequenceEqual(CHA)) { vsb.Append("cha"); i++; continue; }
                if (two.SequenceEqual(CHU)) { vsb.Append("chu"); i++; continue; }
                if (two.SequenceEqual(CHO)) { vsb.Append("cho"); i++; continue; }
                if (two.SequenceEqual(NYA)) { vsb.Append("nya"); i++; continue; }
                if (two.SequenceEqual(NYU)) { vsb.Append("nyu"); i++; continue; }
                if (two.SequenceEqual(NYO)) { vsb.Append("nyo"); i++; continue; }
                if (two.SequenceEqual(HYA)) { vsb.Append("hya"); i++; continue; }
                if (two.SequenceEqual(HYU)) { vsb.Append("hyu"); i++; continue; }
                if (two.SequenceEqual(HYO)) { vsb.Append("hyo"); i++; continue; }
                if (two.SequenceEqual(MYA)) { vsb.Append("mya"); i++; continue; }
                if (two.SequenceEqual(MYU)) { vsb.Append("myu"); i++; continue; }
                if (two.SequenceEqual(MYO)) { vsb.Append("myo"); i++; continue; }
                if (two.SequenceEqual(RYA)) { vsb.Append("rya"); i++; continue; }
                if (two.SequenceEqual(RYU)) { vsb.Append("ryu"); i++; continue; }
                if (two.SequenceEqual(RYO)) { vsb.Append("ryo"); i++; continue; }
                if (two.SequenceEqual(GYA)) { vsb.Append("gya"); i++; continue; }
                if (two.SequenceEqual(GYU)) { vsb.Append("gyu"); i++; continue; }
                if (two.SequenceEqual(GYO)) { vsb.Append("gyo"); i++; continue; }
                if (two.SequenceEqual(JA)) { vsb.Append("ja"); i++; continue; }
                if (two.SequenceEqual(JU)) { vsb.Append("ju"); i++; continue; }
                if (two.SequenceEqual(JO)) { vsb.Append("jo"); i++; continue; }
                if (two.SequenceEqual(BYA)) { vsb.Append("bya"); i++; continue; }
                if (two.SequenceEqual(BYU)) { vsb.Append("byu"); i++; continue; }
                if (two.SequenceEqual(BYO)) { vsb.Append("byo"); i++; continue; }
                if (two.SequenceEqual(PYA)) { vsb.Append("pya"); i++; continue; }
                if (two.SequenceEqual(PYU)) { vsb.Append("pyu"); i++; continue; }
                if (two.SequenceEqual(PYO)) { vsb.Append("pyo"); i++; continue; }
            }

            // ■ 促音「っ」
            if (c0 == 'っ' && i + 1 < input.Length)
            {
                char next = (input[i + 1] >= 'ァ' && input[i + 1] <= 'ヺ') ? (char)(input[i + 1] - 0x60) : input[i + 1];
                string m = MapSingle(next);
                if (!String.IsNullOrEmpty(m))
                {
                    vsb.Append(m[0]);
                }

                continue;
            }

            // ■ 長音記号「ー」
            if (c0 == 'ー')
            {
                if (vsb.Length > 0)
                {
                    vsb.Append(vsb[vsb.Length - 1]);
                }

                continue;
            }

            // ■ 単音・濁音・半濁音
            vsb.Append(MapSingle(c0));
        }

        return vsb.ToString();
    }

    /// <summary>
    /// ひらがな1文字をローマ字に変換します。
    /// </summary>
    /// <param name="hira">変換対象のひらがな1文字</param>
    /// <returns>ローマ字文字列</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string MapSingle(char hira) => hira switch
    {
        'あ' => "a",
        'い' => "i",
        'う' => "u",
        'え' => "e",
        'お' => "o",
        'か' => "ka",
        'き' => "ki",
        'く' => "ku",
        'け' => "ke",
        'こ' => "ko",
        'さ' => "sa",
        'し' => "shi",
        'す' => "su",
        'せ' => "se",
        'そ' => "so",
        'た' => "ta",
        'ち' => "chi",
        'つ' => "tsu",
        'て' => "te",
        'と' => "to",
        'な' => "na",
        'に' => "ni",
        'ぬ' => "nu",
        'ね' => "ne",
        'の' => "no",
        'は' => "ha",
        'ひ' => "hi",
        'ふ' => "fu",
        'へ' => "he",
        'ほ' => "ho",
        'ま' => "ma",
        'み' => "mi",
        'む' => "mu",
        'め' => "me",
        'も' => "mo",
        'や' => "ya",
        'ゆ' => "yu",
        'よ' => "yo",
        'ら' => "ra",
        'り' => "ri",
        'る' => "ru",
        'れ' => "re",
        'ろ' => "ro",
        'わ' => "wa",
        'を' => "wo",
        'ん' => "n",
        'が' => "ga",
        'ぎ' => "gi",
        'ぐ' => "gu",
        'げ' => "ge",
        'ご' => "go",
        'ざ' => "za",
        'じ' => "ji",
        'ず' => "zu",
        'ぜ' => "ze",
        'ぞ' => "zo",
        'だ' => "da",
        'ぢ' => "ji",
        'づ' => "zu",
        'で' => "de",
        'ど' => "do",
        'ば' => "ba",
        'び' => "bi",
        'ぶ' => "bu",
        'べ' => "be",
        'ぼ' => "bo",
        'ぱ' => "pa",
        'ぴ' => "pi",
        'ぷ' => "pu",
        'ぺ' => "pe",
        'ぽ' => "po",
        'ぁ' => "a",
        'ぃ' => "i",
        'ぅ' => "u",
        'ぇ' => "e",
        'ぉ' => "o",
        'ゃ' => "ya",
        'ゅ' => "yu",
        'ょ' => "yo",
        'ゎ' => "wa",
        _ => hira.ToString(),
    };

    /// <summary>
    /// Stackalloc と ArrayPool を組み合わせた高速かつ低GCの StringBuilder 構造体です。
    /// </summary>
    internal ref struct ValueStringBuilder : IDisposable
    {
        /// <summary>プールに返却する配列</summary>
        private char[]? _arrayToReturnToPool;
        /// <summary>文字バッファ</summary>
        private Span<char> _chars;
        /// <summary>現在の位置</summary>
        private int _pos;

        /// <summary>
        /// 初期バッファを指定して ValueStringBuilder を初期化します。
        /// </summary>
        /// <param name="initialBuffer">初期バッファ</param>
        public ValueStringBuilder(Span<char> initialBuffer)
        {
            this._arrayToReturnToPool = null;
            this._chars = initialBuffer;
            this._pos = 0;
        }

        /// <summary>
        /// 文字列の長さを取得します。
        /// </summary>
        public int Length => this._pos;

        /// <summary>
        /// 指定された位置の文字を取得します。
        /// </summary>
        /// <param name="index">文字の位置</param>
        public char this[int index] => this._chars[index];

        /// <summary>
        /// 文字を追加します。
        /// </summary>
        /// <param name="c">追加する文字</param>
        public void Append(char c)
        {
            if (this._pos >= this._chars.Length)
            {
                this.Grow();
            }
            this._chars[this._pos++] = c;
        }

        /// <summary>
        /// 文字列を追加します。
        /// </summary>
        /// <param name="s">追加する文字列</param>
        public void Append(string s)
        {
            foreach (char c in s)
            {
                this.Append(c);
            }
        }

        /// <summary>
        /// バッファを拡張します。
        /// </summary>
        private void Grow()
        {
            char[] newArray = ArrayPool<char>.Shared.Rent(this._chars.Length * 2);
            this._chars.CopyTo(newArray);
            if (this._arrayToReturnToPool != null)
            {
                ArrayPool<char>.Shared.Return(this._arrayToReturnToPool);
            }

            this._chars = newArray;
            this._arrayToReturnToPool = newArray;
        }

        /// <summary>
        /// 文字列を返却し、リソースを解放します。
        /// </summary>
        /// <returns>構築された文字列</returns>
        public override string ToString()
        {
            string result = this._chars.Slice(0, this._pos).ToString();
            this.Dispose();
            return result;
        }

        /// <summary>
        /// リソースを解放します。
        /// </summary>
        public void Dispose()
        {
            if (this._arrayToReturnToPool != null)
            {
                ArrayPool<char>.Shared.Return(this._arrayToReturnToPool);
                this._arrayToReturnToPool = null;
            }
        }
    }
}
