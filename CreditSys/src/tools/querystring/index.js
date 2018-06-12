// QueryString
// ---------------
// This module provides utilities for dealing with query strings.
//
// Thanks to:
//  - http://nodejs.org/docs/v0.4.7/api/querystring.html
//  - http://developer.yahoo.com/yui/3/api/QueryString.html
//  - https://github.com/lifesinger/dew/tree/master/lib/querystring

var QueryString = exports;

// The escape/unescape function used by stringify/parse, provided so that it
// could be overridden if necessary. This is important in cases where
// non-standard delimiters are used, if the delimiters would not normally be
// handled properly by the built-in (en|de)codeURIComponent functions.
QueryString.escape = encodeURIComponent;

QueryString.unescape = function (s) {
  // The + character is interpreted as a space on the server side as well as
  // generated by forms with spaces in their fields.
  return decodeURIComponent(s.replace(/\+/g, ' '));
};

/**
 * Serialize an object to a query string. Optionally override the default
 * separator and assignment characters.
 *
 * stringify({foo: 'bar'})
 *   // returns 'foo=bar'
 *
 * stringify({foo: 'bar', baz: 'bob'}, ';', ':')
 *   // returns 'foo:bar;baz:bob'
 */
QueryString.stringify = function (obj, sep, eq, arrayKey) {
  if (!isPlainObject(obj)) return '';

  sep = sep || '&';
  eq = eq || '=';
  arrayKey = arrayKey || false;

  var buf = [],
    key, val;
  var escape = QueryString.escape;

  for (key in obj) {
    if (!hasOwnProperty.call(obj, key)) continue;

    val = obj[key];
    key = QueryString.escape(key);

    // val is primitive value
    if (isPrimitive(val)) {
      buf.push(key, eq, escape(val + ''), sep);
    }
    // val is not empty array
    else if (isArray(val) && val.length) {
      for (var i = 0; i < val.length; i++) {
        if (isPrimitive(val[i])) {
          buf.push(
            key,
            (arrayKey ? escape('[]') : '') + eq,
            escape(val[i] + ''),
            sep);
        }
      }
    }
    // ignore other cases, including empty array, Function, RegExp, Date etc.
    else {
      buf.push(key, eq, sep);
    }
  }

  buf.pop();
  return buf.join('');
};

/**
 * Deserialize a query string to an object. Optionally override the default
 * separator and assignment characters.
 *
 * parse('a=b&c=d')
 *   // returns {a: 'b', c: 'c'}
 */
QueryString.parse = function (str, sep, eq) {
  if (typeof str === 'undefined') {
    str = document.location.search
  }
  var ret = {};

  if (typeof str !== 'string' || trim(str).length === 0) {
    return ret;
  }

  // remove ^?
  str = str.replace(/^\?/, '');

  var pairs = str.split(sep || '&');
  eq = eq || '=';
  var unescape = QueryString.unescape;

  for (var i = 0; i < pairs.length; i++) {

    var pair = pairs[i].split(eq);
    var key = unescape(trim(pair[0]));
    var val = unescape(trim(pair.slice(1).join(eq)));

    var m = key.match(/^(\w+)\[\]$/);
    if (m && m[1]) {
      key = m[1];
    }

    if (hasOwnProperty.call(ret, key)) {
      if (!isArray(ret[key])) {
        ret[key] = [ret[key]];
      }
      ret[key].push(val);
    } else {
      ret[key] = m ? [val] : val;
    }
  }

  return ret;
};

// Helpers

var toString = Object.prototype.toString;
var hasOwnProperty = Object.prototype.hasOwnProperty;
var isArray = Array.isArray || function (val) {
  return toString.call(val) === '[object Array]';
};
var trim = String.prototype.trim ?
  function (str) {
    return (str == null) ?
      '' :
      String.prototype.trim.call(str);
  } :
  function (str) {
    return (str == null) ?
      '' :
      str.toString().replace(/^\s+/, '').replace(/\s+$/, '');
  };

/**
 * Checks to see if an object is a plain object (created using "{}" or
 * "new Object()" or "new FunctionClass()").
 */
function isPlainObject(o) {
  /**
   * NOTES:
   * isPlainObject(node = document.getElementById("xx")) -> false
   * toString.call(node):
   *   ie678 === '[object Object]', other === '[object HTMLElement]'
   * 'isPrototypeOf' in node:
   *   ie678 === false, other === true
   */
  return o &&
    toString.call(o) === '[object Object]' &&
    'isPrototypeOf' in o;
}

/**
 * If the type of o is null, undefined, number, string, boolean,
 * return true.
 */
function isPrimitive(o) {
  return o !== Object(o);
}