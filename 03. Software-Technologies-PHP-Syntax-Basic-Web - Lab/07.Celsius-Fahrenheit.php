<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Celsius to Fahrenheit Converter</title>
</head>
<body>
<?php
    function celsiusToFahrenheit(float $celsius):float
    {
        return $celsius * 1.8 + 32;
    }

    function fahrenheitToCelsius(float $fahrenheit):float
    {
        return ($fahrenheit - 32) / 1.8;
    }

    $msgAfterCelsius = "";
    if(isset($_GET['cel'])){
        $celsius = floatval($_GET['cel']);
        $fahrenheit = celsiusToFahrenheit($celsius);
        $msgAfterCelsius = "$celsius &deg;C = $fahrenheit &deg;F";
    }

    $msgAfterFahrenheit ="";
    if(isset($_GET['fah'])){
        $fahrenheit = floatval($_GET['fah']);
        $celsius = fahrenheitToCelsius($fahrenheit);
        $msgAfterFahrenheit = "$fahrenheit &deg;F = $celsius &deg;C";
    }
?>
    <form>
        <span>Celsius:</span>
        <input type="text" name="cel" />
        <input type="submit" value="Convert">
        <?=$msgAfterCelsius?>
    </form>

    <form>
        <span>Fahrenheit:</span>
        <input type="text" name="fah" />
        <input type="submit" value="Convert">
        <?=$msgAfterFahrenheit?>
    </form>
</body>
</html>