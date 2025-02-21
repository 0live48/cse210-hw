class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public bool IsHidden => _isHidden;

    public void Hide()
    {
        _isHidden = true;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
            return _text.Length > 0 ? $"{_text[0]}{new string('_', _text.Length - 1)}" : "";
        return _text;
    }

    public string GetFullyHiddenText()
    {
        return new string('_', _text.Length);
    }
}
