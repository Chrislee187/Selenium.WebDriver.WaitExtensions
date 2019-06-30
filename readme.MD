More and more (most?) websites these days require asyncronous behavior, either because of AJAX calls to the back end, or, as is becoming more common, the JS presentation/binding/MVVM framework (such as Angular, React, Knockout ) uses asyncronicity to use create a responsive and maintainable user experience.

These solutions often means that simple Selenium test code requires some form of "wait" between executing an action and checking it's results.

The Selenium.WebDriver.Support package offers a WebDriverWait class that offers some waiting support but this can be cumbersome to use to create individual delays for a specific piece of behaviour.

Enter Selenium.WebDriver.WaitExtensions, some simple extension methods to make testing Selenium.WebDriver testing of async behaviour at little nicer and a little less cumbersome.

QUICK EXAMPLES
Wait 2500ms for an element to appear in the DOM
	```var webelement = webdriver.Wait(2500).ForElement(By.Id("dynamicElement").ToExist()```

Wait 150ms for a specific class to attach to an element
	```webelement.Wait(150).ForClass().ToContains("my-new-class")```

All checks have an Opposite 'Not' check i.e `ToExist()/ToNotExist()`
`WebDriverTimeoutException` thrown when timeout is reached

There are several "waits" available for WebElements including;
	`ForClass()` to check for changes to the 'class' attribute of the element
	`ForText()` to check for changes to the 'text' attribute of the element
	`ForAttribute()` to check for changes to individual attributes of the element
	`ForElement()` to check for element level property changes, such as 'disabled', 'displayed' & selected
	`ForPage()` to check for page level changes such as Url, Title, document.readyState

	See the Tests for complete examples
