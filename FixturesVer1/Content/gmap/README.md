jQuery Latitude and Longitude Picker for Google Maps
====================================================

**A jQuery Latitude and Longitude plugin to pick a location using Google Maps.**

Supports multiple maps. Works on touchscreen. Easy to customize markup and CSS.

[Check out the live demos.](http://www.wimagguc.com/2013/06/jquery-latitude-and-longitude-picker-gmaps/)


FEATURES
========

**Basic functions**

- Move the marker on the map to receive the updated latitude, longitude and zoom values in the hidden fields

- "location_changed" event will be fired, with the gllLatlonPicker Node JS object as attribute for easy access

**Map with location search field:**

- If the search has results, the first element will appear on the map (with the default zoom value 11)

- You can set default latitude, longitude and zoom values in the hidden fields

- Use any custom id you want

**Map with reverse lookup:**

- WHen the position changes the location's name will be returned

- The "location_changed" event will also be fired with the gllLatlonPicker Node JS object as attribute

- To disable this, you can set queryLocationNameWhenLatLngChanges param to false

**Adjust latitude, longitude and zoom fields on the fly:**

- Set any default latitude, longitude and zoom values. The map shows your data after pressing the update button.

- Any fields can be hidden or visible fields to ease user input


INSTALL
=======

Import jQuery and Google Maps:

```
  <script src="js/jquery-2.1.1.min.js"></script>
  <script src="http://maps.googleapis.com/maps/api/js?sensor=false"></script>
```

Import the plugin:

```
  <link rel="stylesheet" type="text/css" href="css/jquery-gmaps-latlon-picker.css"/>
  <script src="js/jquery-gmaps-latlon-picker.js"></script>
```

Add a HTML markup:

```
  <fieldset class="gllpLatlonPicker">
    <input type="text" class="gllpSearchField">
    <input type="button" class="gllpSearchButton" value="search">
	<div class="gllpMap">Google Maps</div>
	<input type="hidden" class="gllpLatitude" value="20"/>
	<input type="hidden" class="gllpLongitude" value="20"/>
	<input type="hidden" class="gllpZoom" value="3"/>
  </fieldset>
```

(See more options in the demo.html)


LICENSE
=======

[MIT, do-with-the-code-whatever-you-please License](https://github.com/wimagguc/jquery-latitude-longitude-picker-gmaps/blob/master/LICENSE.md)

This code uses the jQuery Javascript library and the Google Maps API. To read more about these, go to:  

- [jquery.com](http://jquery.com/)
- [developers.google.com/maps](https://developers.google.com/maps/)


ABOUT
=====

Richard Dancsi

- Blog: [wimagguc.com](http://www.wimagguc.com/)
- Twitter: [twitter.com/wimagguc](http://twitter.com/wimagguc)
- Linkedin: [linkedin.com/in/richarddancsi](http://linkedin.com/in/richarddancsi)
- Google+: [plus.google.com/u/0/115939246085616544919](https://plus.google.com/u/0/115939246085616544919)
