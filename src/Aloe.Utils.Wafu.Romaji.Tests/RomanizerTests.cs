namespace Aloe.Utils.Wafu.JisCompat.Tests;

using Xunit;
using Aloe.Utils.Wafu.Romaji;
using Xunit.Abstractions;
using System.ComponentModel.DataAnnotations;

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
    [Display(Name = "基本文字が正しく変換されること")]
    public void Convert_BasicCharacters_ConvertsCorrectly(string input, string expected)
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
    [Display(Name = "濁音・半濁音が正しく変換されること")]
    public void Convert_DakutenAndHandakuten_ConvertsCorrectly(string input, string expected)
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
    [Display(Name = "拗音が正しく変換されること")]
    public void Convert_Yoon_ConvertsCorrectly(string input, string expected)
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
    [Display(Name = "促音が正しく変換されること")]
    public void Convert_Sokuon_ConvertsCorrectly(string input, string expected)
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
    [Display(Name = "長音が正しく変換されること")]
    public void Convert_LongVowel_ConvertsCorrectly(string input, string expected)
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
    [Display(Name = "小文字が正しく変換されること")]
    public void Convert_SmallCharacters_ConvertsCorrectly(string input, string expected)
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
    [Display(Name = "カタカナが正しく変換されること")]
    public void Convert_Katakana_ConvertsCorrectly(string input, string expected)
    {
        // Arrange & Act
        var actual = Romanizer.Convert(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("あい123", "ai123")]
    [InlineData("カタカナ123", "katakana123")]
    [InlineData("あい うえ", "ai ue")]
    [InlineData("あい\nうえ", "ai\nue")]
    [InlineData(null, "")]
    [InlineData("", "")]
    [Display(Name = "特殊文字が正しく変換されること")]
    public void Convert_SpecialCharacters_ConvertsCorrectly(string? input, string expected)
    {
        // Arrange & Act
        var actual = Romanizer.Convert(input);

        // Assert
        Assert.Equal(expected, actual);
    }
}
