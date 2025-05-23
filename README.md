# Selenium

- Для сайту https://www.selenium.dev/selenium/web/web-form.html .

```C#
private string url = "https://www.selenium.dev/selenium/web/web-form.html";
...
driver.Navigate().GoToUrl(url);
```

- Реалізувати принаймні 3 тестові сценарії використовуючи бібліотеку Selenium.
- Кожен сценарій повинен взаємодіяти принаймні з 2 елементами.
- Повинні перевірятися результати взаємодії.

# Test 1

```C#
[Test]
public void TextboxColor()
{
	string green = "#00ff00";

	// Елемент 1
	Get(By.Name("my-text")).SendKeys(green);
	// Перевірка
	Assert.That(Get(By.Name("my-text")).GetAttribute("value"), Is.EqualTo(green));

	// Елемент 2
	((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].value = arguments[1];", Get(By.Name("my-colors")), green);
	// Перевірка
	Assert.That(Get(By.Name("my-colors")).GetAttribute("value"), Is.EqualTo(green));

	// Формальна взаємодія
	Get(By.CssSelector("button")).Click();
	Assert.That(Get(By.Id("message")).Text, Is.EqualTo("Received!"));
}
```

# Test 2

```C#
[Test]
public void DropdownCheckbox()
{
	// Елемент 1
	Get(By.Name("my-select")).FindElement(By.CssSelector("option[value='2']")).Click();
	// Перевірка
	Assert.That(Get(By.Name("my-select")).GetAttribute("value"), Is.EqualTo("2"));

	// Елемент 2
	Get(By.Id("my-check-1")).Click();
	// Перевірка
	Assert.That(Get(By.Id("my-check-1")).GetAttribute("checked"), Is.Not.Empty);

	// Формальна взаємодія
	Get(By.CssSelector("button")).Click();
	Assert.That(Get(By.Id("message")).Text, Is.EqualTo("Received!"));
}
```

# Test 3

```C#
[Test]
public void DatetimeRadio()
{
	// Елемент 1
	Get(By.Name("my-date")).SendKeys("2025-05-03");
	// Перевірка
	Assert.That(Get(By.Name("my-date")).GetAttribute("value"), Is.EqualTo("2025-05-03"));

	// Елемент 2
	Get(By.Id("my-radio-1")).Click();
	// Перевірка
	Assert.Multiple(() =>
	{
		Assert.That(Get(By.Id("my-radio-1")).GetAttribute("checked"), Is.Not.Empty);
		Assert.That(Get(By.Id("my-radio-2")).GetAttribute("checked"), Is.Null);
	});

	// Формальна взаємодія
	Get(By.CssSelector("button")).Click();
	Assert.That(Get(By.Id("message")).Text, Is.EqualTo("Received!"));
}
```

# Висновки

Бібліотека Selenium пропонує усі необхідні інструменти для автоматизації взаємодії користувача з веб інтерфейсом.