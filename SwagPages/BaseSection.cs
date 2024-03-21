using OpenQA.Selenium;

namespace SwagPages
{
    public abstract class BaseSection : Utilities
    {
        private IWebElement _content;
        private readonly By _by;
        private readonly IWebElement _parent;

        internal IWebElement Content { get
            { 
                if (_content == null)
                {
                    _content = _parent != null ?
                        _parent.FindElement(_by) :
                        _driver.FindElement(_by);
                }
                return _content;
            }
        }

        internal BaseSection(IWebDriver driver, By by) : base(driver)
        {
            _by = by;
        }

        internal BaseSection(IWebDriver driver, By by, IWebElement parent) : base(driver)
        {
            _by = by;
            _parent = parent;
        }
    }
}
