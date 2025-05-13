namespace Aloe.Utils.Wafu.JisCompat.Tests;

using Xunit;
using Aloe.Utils.Wafu.Romaji;

/// <summary>
/// Romanizer クラスのテスト
/// </summary>
public class RomanizerTests
{
    [Theory]
    [InlineData("", "")]
    [InlineData("あいうえお", "aiueo")]
    [InlineData("かきくけこ", "kakikukeko")]
    [InlineData("さしすせそ", "sashisuseso")]
    [InlineData("たちつてと", "tachitsuteto")]
    [InlineData("なにぬねの", "naninuneno")]
    [InlineData("はひふへほ", "hahifuheho")]
    [InlineData("まみむめも", "mamimumemo")]
    [InlineData("やゆよ", "yayuyo")]
    [InlineData("らりるれろ", "rarirurero")]
    [InlineData("わをん", "wawon")]
    public void Convert_基本文字_正しく変換される(string input, string expected)
    {
        // Arrange & Act
        var actual = Romanizer.Convert(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("がぎぐげご", "gagigugego")]
    [InlineData("ざじずぜぞ", "zajizuzezo")]
    [InlineData("だぢづでど", "dajizudedo")]
    [InlineData("ばびぶべぼ", "babibubebo")]
    [InlineData("ぱぴぷぺぽ", "papipupepo")]
    public void Convert_濁音半濁音_正しく変換される(string input, string expected)
    {
        // Arrange & Act
        var actual = Romanizer.Convert(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("きゃきゅきょ", "kyakyukyo")]
    [InlineData("しゃしゅしょ", "shashusho")]
    [InlineData("ちゃちゅちょ", "chachucho")]
    [InlineData("にゃにゅにょ", "nyanyunyo")]
    [InlineData("ひゃひゅひょ", "hyahyuhyo")]
    [InlineData("みゃみゅみょ", "myamyumyo")]
    [InlineData("りゃりゅりょ", "ryaryuryo")]
    [InlineData("ぎゃぎゅぎょ", "gyagyugyo")]
    [InlineData("じゃじゅじょ", "jajujo")]
    [InlineData("びゃびゅびょ", "byabyubyo")]
    [InlineData("ぴゃぴゅぴょ", "pyapyupyo")]
    public void Convert_拗音_正しく変換される(string input, string expected)
    {
        // Arrange & Act
        var actual = Romanizer.Convert(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("っか", "kka")]
    [InlineData("っき", "kki")]
    [InlineData("っく", "kku")]
    [InlineData("っけ", "kke")]
    [InlineData("っこ", "kko")]
    [InlineData("っさ", "ssa")]
    [InlineData("っし", "sshi")]
    [InlineData("っす", "ssu")]
    [InlineData("っせ", "sse")]
    [InlineData("っそ", "sso")]
    [InlineData("った", "tta")]
    [InlineData("っち", "cchi")]
    [InlineData("っつ", "ttsu")]
    [InlineData("って", "tte")]
    [InlineData("っと", "tto")]
    public void Convert_促音_正しく変換される(string input, string expected)
    {
        // Arrange & Act
        var actual = Romanizer.Convert(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("あー", "aa")]
    [InlineData("いー", "ii")]
    [InlineData("うー", "uu")]
    [InlineData("えー", "ee")]
    [InlineData("おー", "oo")]
    public void Convert_長音_正しく変換される(string input, string expected)
    {
        // Arrange & Act
        var actual = Romanizer.Convert(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("あぁ", "aa")]
    [InlineData("いぃ", "ii")]
    [InlineData("うぅ", "uu")]
    [InlineData("えぇ", "ee")]
    [InlineData("おぉ", "oo")]
    public void Convert_小文字_正しく変換される(string input, string expected)
    {
        // Arrange & Act
        var actual = Romanizer.Convert(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("ア", "a")]
    [InlineData("イ", "i")]
    [InlineData("ウ", "u")]
    [InlineData("エ", "e")]
    [InlineData("オ", "o")]
    [InlineData("カ", "ka")]
    [InlineData("キ", "ki")]
    [InlineData("ク", "ku")]
    [InlineData("ケ", "ke")]
    [InlineData("コ", "ko")]
    public void Convert_カタカナ_正しく変換される(string input, string expected)
    {
        // Arrange & Act
        var actual = Romanizer.Convert(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("あい", "ai")]
    [InlineData("うえお", "ueo")]
    [InlineData("かきく", "kakiku")]
    [InlineData("さしすせそ", "sashisuseso")]
    public void Convert_複合文字_正しく変換される(string input, string expected)
    {
        // Arrange & Act
        var actual = Romanizer.Convert(input);

        // Assert
        Assert.Equal(expected, actual);
    }
}
