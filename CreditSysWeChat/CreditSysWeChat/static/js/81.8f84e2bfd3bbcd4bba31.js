webpackJsonp([81],{1499:function(t,n,e){var i=e(1500);"string"==typeof i&&(i=[[t.i,i,""]]),i.locals&&(t.exports=i.locals);e(227)("9bc373b6",i,!0)},1500:function(t,n,e){n=t.exports=e(226)(),n.push([t.i,"\n.record-component[data-v-2552c2ec] {\n  padding: 10px 0 0;\n}\n.value-range[data-v-2552c2ec] {\n  margin-top: 20px;\n  margin-bottom: 20px;\n  margin-right: 40px !important;\n  margin-left: 40px !important;\n}\n",""])},1501:function(t,n,e){"use strict";var i=e(679);n.a={data:function(){return{number:10,min:0,max:250,step:1,rangeBarHeight:4,error:null}},components:{Range:i.a}}},1502:function(t,n,e){"use strict";var i=function(){var t=this,n=t.$createElement,e=t._self._c||n;return e("div",{staticClass:"record-component"},[e("div",[t._v(t._s(t.number))]),t._v(" "),e("range",{staticClass:"value-range",attrs:{min:t.min,max:t.max,step:t.step,"range-bar-height":t.rangeBarHeight,decimal:""},model:{value:t.number,callback:function(n){t.number=n},expression:"number"}})],1)},s=[],o={render:i,staticRenderFns:s};n.a=o},365:function(t,n,e){"use strict";function i(t){e(1499)}Object.defineProperty(n,"__esModule",{value:!0});var s=e(1501),o=e(1502),r=e(0),a=i,l=r(s.a,o.a,a,"data-v-2552c2ec",null);n.default=l.exports},562:function(t,n){var e=window.addEventListener?"addEventListener":"attachEvent",i=window.removeEventListener?"removeEventListener":"detachEvent",s="addEventListener"!==e?"on":"";n.bind=function(t,n,i,o){return t[e](s+n,i,o||!1),i},n.unbind=function(t,n,e,o){return t[i](s+n,e,o||!1),e}},595:function(t,n,e){"use strict";function i(t){var n=window.getComputedStyle(t,null).width;return"100%"===n||"auto"===n?0:parseInt(n,10)}Object.defineProperty(n,"__esModule",{value:!0}),e.d(n,"indexof",function(){return s}),e.d(n,"findClosest",function(){return o}),e.d(n,"getWidth",function(){return i}),e.d(n,"percentage",function(){return r});var s=function(t,n){if(t.indexOf)return t.indexOf(n);for(var e=0;e<t.length;++e)if(t[e]===n)return e;return-1},o=function(t,n){for(var e=null,i=n[0],s=0;s<n.length;s++)e=Math.abs(t-i),Math.abs(t-n[s])<e&&(i=n[s]);return i},r={isNumber:function(t){return"number"==typeof t},of:function(t,n){if(r.isNumber(t)&&r.isNumber(n))return t/100*n},from:function(t,n){if(r.isNumber(t)&&r.isNumber(n))return t/n*100}}},679:function(t,n,e){"use strict";function i(t){e(680)}var s=e(682),o=e(692),r=e(0),a=i,l=r(s.a,o.a,a,null,null);n.a=l.exports},680:function(t,n,e){var i=e(681);"string"==typeof i&&(i=[[t.i,i,""]]),i.locals&&(t.exports=i.locals);e(227)("810caff8",i,!0)},681:function(t,n,e){n=t.exports=e(226)(),n.push([t.i,"/**\n* actionsheet\n*/\n/**\n* datetime\n*/\n/**\n* tabbar\n*/\n/**\n* tab\n*/\n/**\n* dialog\n*/\n/**\n* x-number\n*/\n/**\n* checkbox\n*/\n/**\n* check-icon\n*/\n/**\n* Cell\n*/\n/**\n* Mask\n*/\n/**\n* Range\n*/\n/**\n* Tabbar\n*/\n/**\n* Header\n*/\n/**\n* Timeline\n*/\n/**\n* Switch\n*/\n/**\n* Button\n*/\n/**\n* swipeout\n*/\n/**\n* Cell\n*/\n/**\n* Badge\n*/\n/**\n* Popover\n*/\n/**\n* Button tab\n*/\n/* alias */\n/**\n* Swiper\n*/\n/**\n* checklist\n*/\n/**\n* popup-picker\n*/\n/**\n* popup\n*/\n/**\n* popup-header\n*/\n/**\n* form-preview\n*/\n/**\n* load-more\n*/\n/**\n* sticky\n*/\n/**\n* group\n*/\n/**\n* toast\n*/\n/**\n* icon\n*/\n/**\n* calendar\n*/\n/**\n* search\n*/\n/**\n* radio\n*/\n/**\n *\n * Main stylesheet for Powerange.\n * http://abpetkov.github.io/powerange/\n *\n */\n/**\n * Horizontal slider style (default).\n */\n.range-bar {\n  background-color: #a9acb1;\n  border-radius: 15px;\n  display: block;\n  height: 1px;\n  position: relative;\n  width: 100%;\n}\n.range-bar-disabled {\n  opacity: 0.5;\n}\n.range-quantity {\n  background-color: #FF9900;\n  border-radius: 15px;\n  display: block;\n  height: 100%;\n  width: 0;\n}\n.range-handle {\n  background-color: #fff;\n  border-radius: 100%;\n  cursor: move;\n  height: 30px;\n  left: 0;\n  top: -13px;\n  position: absolute;\n  width: 30px;\n  box-shadow: 0 1px 3px rgba(0, 0, 0, 0.4);\n}\n.range-min,\n.range-max {\n  color: #181819;\n  font-size: 12px;\n  position: absolute;\n  text-align: center;\n  top: 50%;\n  -webkit-transform: translateY(-50%);\n          transform: translateY(-50%);\n  width: 24px;\n}\n.range-min {\n  left: -30px;\n}\n.range-max {\n  right: -30px;\n}\n/**\n * Style for disabling text selection on handle move.\n */\n.unselectable {\n  -webkit-user-select: none;\n          user-select: none;\n}\n/**\n * Style for handle cursor on disabled slider.\n */\n.range-disabled {\n  cursor: default;\n}\n",""])},682:function(t,n,e){"use strict";var i=e(683);n.a={name:"range",props:{decimal:Boolean,value:{default:0,type:Number},min:{type:Number,default:0},minHTML:String,maxHTML:String,max:{type:Number,default:100},step:{type:Number,default:1},disabled:Boolean,disabledOpacity:Number,rangeBarHeight:{type:Number,default:1},rangeHandleHeight:{type:Number,default:30}},created:function(){this.currentValue=this.value},mounted:function(){var t=this,n=this;this.$nextTick(function(){var e={callback:function(t){n.currentValue=t},decimal:t.decimal,start:t.currentValue,min:t.min,max:t.max,minHTML:t.minHTML,maxHTML:t.maxHTML,disable:t.disabled,disabledOpacity:t.disabledOpacity,initialBarWidth:window.getComputedStyle(t.$el.parentNode).width.replace("px","")-80};0!==t.step&&(e.step=t.step),t.range=new i.a(t.$el.querySelector(".vux-range-input"),e);var s=(t.rangeHandleHeight-t.rangeBarHeight)/2;t.$el.querySelector(".range-handle").style.top="-"+s+"px",t.$el.querySelector(".range-bar").style.height=t.rangeBarHeight+"px",t.handleOrientationchange=function(){t.update()},window.addEventListener("orientationchange",t.handleOrientationchange,!1)})},methods:{update:function(){console.log("update",this.currentValue);var t=this.currentValue;t<this.min&&(t=this.min),t>this.max&&(t=this.max),this.range.reInit({min:this.min,max:this.max,step:this.step,value:t}),this.currentValue=t,this.range.setStart(this.currentValue),this.range.setStep()}},data:function(){return{currentValue:0}},watch:{currentValue:function(t){this.range&&this.range.setStart(t),this.$emit("input",t),this.$emit("on-change",t)},value:function(t){this.currentValue=t},min:function(){this.update()},step:function(){this.update()},max:function(){this.update()}},beforeDestroy:function(){window.removeEventListener("orientationchange",this.handleOrientationchange,!1)}}},683:function(t,n,e){"use strict";function i(t,n){this.element=t,this.options=n||{},this.slider=this.create("span","range-bar"),this.hasAppend=!1,null!==this.element&&"text"===this.element.type&&this.init(),this.options.step&&this.step(this.slider.offsetWidth||this.options.initialBarWidth,r(this.handle)),this.setStart(this.options.start)}var s=e(595),o=s.findClosest,r=s.getWidth,a=s.percentage,l=e(684),u=e(685),h=e(687);i.prototype.setStart=function(t){var n=null===t?this.options.min:t,e=a.from(n-this.options.min,this.options.max-this.options.min)||0,i=a.of(e,this.slider.offsetWidth-this.handle.offsetWidth),s=this.options.step?o(i,this.steps):i;this.setPosition(s),this.setValue(this.handle.style.left,this.slider.offsetWidth-this.handle.offsetWidth)},i.prototype.setStep=function(){this.step(r(this.slider)||this.options.initialBarWidth,r(this.handle))},i.prototype.setPosition=function(t){this.handle.style.left=t+"px",this.slider.querySelector(".range-quantity").style.width=t+"px"},i.prototype.onmousedown=function(t){t.touches&&(t=t.touches[0]),this.startX=t.clientX,this.handleOffsetX=this.handle.offsetLeft,this.restrictHandleX=this.slider.offsetWidth-this.handle.offsetWidth,this.unselectable(this.slider,!0)},i.prototype.changeEvent=function(t){if("function"!=typeof Event&&document.fireEvent)this.element.fireEvent("onchange");else{var n=document.createEvent("HTMLEvents");n.initEvent("change",!1,!0),this.element.dispatchEvent(n)}},i.prototype.onmousemove=function(t){t.preventDefault(),t.touches&&(t=t.touches[0]);var n=this.handleOffsetX+t.clientX-this.startX,e=this.steps?o(n,this.steps):n;n<=0?this.setPosition(0):n>=this.restrictHandleX?this.setPosition(this.restrictHandleX):this.setPosition(e),this.setValue(this.handle.style.left,this.slider.offsetWidth-this.handle.offsetWidth)},i.prototype.unselectable=function(t,n){l(this.slider).has("unselectable")||!0!==n?l(this.slider).remove("unselectable"):l(this.slider).add("unselectable")},i.prototype.onmouseup=function(t){this.unselectable(this.slider,!1)},i.prototype.disable=function(t){(this.options.disable||t)&&(this.mouse.unbind(),this.touch.unbind()),this.options.disable&&(this.options.disableOpacity&&(this.slider.style.opacity=this.options.disableOpacity),l(this.slider).add("range-bar-disabled"))},i.prototype.init=function(){this.hide(),this.append(),this.bindEvents(),this.checkValues(this.options.start),this.setRange(this.options.min,this.options.max),this.disable()},i.prototype.reInit=function(t){this.options.start=t.value,this.options.min=t.min,this.options.max=t.max,this.options.step=t.step,this.disable(!0),this.init()},i.prototype.checkStep=function(t){return t<0&&(t=Math.abs(t)),this.options.step=t,this.options.step},i.prototype.setValue=function(t,n){var e=a.from(parseFloat(t),n);if("0px"===t||0===n)i=this.options.min;else{var i=a.of(e,this.options.max-this.options.min)+this.options.min;i=this.options.decimal?Math.round(100*i)/100:Math.round(i),i>this.options.max&&(i=this.options.max)}var s=!1;s=this.element.value!==i,this.element.value=i,this.options.callback(i),s&&this.changeEvent()},i.prototype.checkValues=function(t){t<this.options.min&&(this.options.start=this.options.min),t>this.options.max&&(this.options.start=this.options.max),this.options.min>=this.options.max&&(this.options.min=this.options.max)},i.prototype.step=function(t,n){for(var e=t-n,i=a.from(this.checkStep(this.options.step),this.options.max-this.options.min),s=a.of(i,e),o=[],r=0;r<=e;r+=s)o.push(r);this.steps=o;for(var l=10;l>=0;l--)this.steps[o.length-l]=e-s*l;return this.steps},i.prototype.create=function(t,n){var e=document.createElement(t);return e.className=n,e},i.prototype.insertAfter=function(t,n){t.parentNode.insertBefore(n,t.nextSibling)},i.prototype.setRange=function(t,n){"number"!=typeof t||"number"!=typeof n||this.options.hideRange||(this.slider.querySelector(".range-min").innerHTML=this.options.minHTML||t,this.slider.querySelector(".range-max").innerHTML=this.options.maxHTML||n)},i.prototype.generate=function(){var t={handle:{type:"span",selector:"range-handle"},min:{type:"span",selector:"range-min"},max:{type:"span",selector:"range-max"},quantity:{type:"span",selector:"range-quantity"}};for(var n in t)if(t.hasOwnProperty(n)){var e=this.create(t[n].type,t[n].selector);this.slider.appendChild(e)}return this.slider},i.prototype.append=function(){if(!this.hasAppend){var t=this.generate();this.insertAfter(this.element,t)}this.hasAppend=!0},i.prototype.hide=function(){this.element.style.display="none"},i.prototype.bindEvents=function(){this.handle=this.slider.querySelector(".range-handle"),this.touch=h(this.handle,this),this.touch.bind("touchstart","onmousedown"),this.touch.bind("touchmove","onmousemove"),this.touch.bind("touchend","onmouseup"),this.mouse=u(this.handle,this),this.mouse.bind()};var c={callback:function(){},decimal:!1,disable:!1,disableOpacity:null,hideRange:!1,min:0,max:100,start:null,step:null,vertical:!1};n.a=function(t,n){n=n||{};for(var e in c)null==n[e]&&(n[e]=c[e]);return new i(t,n)}},684:function(t,n,e){function i(t){if(!t||!t.nodeType)throw new Error("A DOM element reference is required");this.el=t,this.list=t.classList}var s=e(595).indexof,o=/\s+/,r=Object.prototype.toString;t.exports=function(t){return new i(t)},i.prototype.add=function(t){if(this.list)return this.list.add(t),this;var n=this.array();return~s(n,t)||n.push(t),this.el.className=n.join(" "),this},i.prototype.remove=function(t){if("[object RegExp]"===r.call(t))return this.removeMatching(t);if(this.list)return this.list.remove(t),this;var n=this.array(),e=s(n,t);return~e&&n.splice(e,1),this.el.className=n.join(" "),this},i.prototype.removeMatching=function(t){for(var n=this.array(),e=0;e<n.length;e++)t.test(n[e])&&this.remove(n[e]);return this},i.prototype.toggle=function(t,n){return this.list?(void 0!==n?n!==this.list.toggle(t,n)&&this.list.toggle(t):this.list.toggle(t),this):(void 0!==n?n?this.add(t):this.remove(t):this.has(t)?this.remove(t):this.add(t),this)},i.prototype.array=function(){var t=this.el.getAttribute("class")||"",n=t.replace(/^\s+|\s+$/g,""),e=n.split(o);return""===e[0]&&e.shift(),e},i.prototype.has=i.prototype.contains=function(t){return this.list?this.list.contains(t):!!~s(this.array(),t)}},685:function(t,n,e){function i(t,n){this.obj=n||{},this.el=t}var s=e(686),o=e(562);t.exports=function(t,n){return new i(t,n)},s(i.prototype),i.prototype.bind=function(){function t(s){e.onmouseup&&e.onmouseup(s),o.unbind(document,"mousemove",n),o.unbind(document,"mouseup",t),i.emit("up",s)}function n(t){e.onmousemove&&e.onmousemove(t),i.emit("move",t)}var e=this.obj,i=this;return i.down=function(s){e.onmousedown&&e.onmousedown(s),o.bind(document,"mouseup",t),o.bind(document,"mousemove",n),i.emit("down",s)},o.bind(this.el,"mousedown",i.down),this},i.prototype.unbind=function(){o.unbind(this.el,"mousedown",this.down),this.down=null}},686:function(t,n){function e(t){if(t)return i(t)}function i(t){for(var n in e.prototype)t[n]=e.prototype[n];return t}t.exports=e,e.prototype.on=e.prototype.addEventListener=function(t,n){return this._callbacks=this._callbacks||{},(this._callbacks["$"+t]=this._callbacks["$"+t]||[]).push(n),this},e.prototype.once=function(t,n){function e(){this.off(t,e),n.apply(this,arguments)}return e.fn=n,this.on(t,e),this},e.prototype.off=e.prototype.removeListener=e.prototype.removeAllListeners=e.prototype.removeEventListener=function(t,n){if(this._callbacks=this._callbacks||{},!arguments.length)return this._callbacks={},this;var e=this._callbacks["$"+t];if(!e)return this;if(1===arguments.length)return delete this._callbacks["$"+t],this;for(var i,s=0;s<e.length;s++)if((i=e[s])===n||i.fn===n){e.splice(s,1);break}return this},e.prototype.emit=function(t){this._callbacks=this._callbacks||{};var n=[].slice.call(arguments,1),e=this._callbacks["$"+t];if(e){e=e.slice(0);for(var i=0,s=e.length;i<s;++i)e[i].apply(this,n)}return this},e.prototype.listeners=function(t){return this._callbacks=this._callbacks||{},this._callbacks["$"+t]||[]},e.prototype.hasListeners=function(t){return!!this.listeners(t).length}},687:function(t,n,e){function i(t,n){if(!(this instanceof i))return new i(t,n);if(!t)throw new Error("element required");if(!n)throw new Error("object required");this.el=t,this.obj=n,this._events={}}function s(t){var n=t.split(/ +/);return{name:n.shift(),selector:n.join(" ")}}var o=e(562),r=e(688);t.exports=i,i.prototype.sub=function(t,n,e){this._events[t]=this._events[t]||{},this._events[t][n]=e},i.prototype.bind=function(t,n){var e=s(t),i=this.el,a=this.obj,l=e.name;n=n||"on"+l;var u=[].slice.call(arguments,2),h=function(){var t=[].slice.call(arguments).concat(u);a[n].apply(a,t)};return e.selector?h=r.bind(i,e.selector,l,h):o.bind(i,l,h),this.sub(l,n,h),h},i.prototype.unbind=function(t,n){if(0===arguments.length)return this.unbindAll();if(1===arguments.length)return this.unbindAllOf(t);var e=this._events[t];if(e){var i=e[n];i&&o.unbind(this.el,t,i)}},i.prototype.unbindAll=function(){for(var t in this._events)this.unbindAllOf(t)},i.prototype.unbindAllOf=function(t){var n=this._events[t];if(n)for(var e in n)this.unbind(t,e)}},688:function(t,n,e){var i=e(689),s=e(562);n.bind=function(t,n,e,o,r){return s.bind(t,e,function(e){var s=e.target||e.srcElement;e.delegateTarget=i(s,n,!0,t),e.delegateTarget&&o.call(t,e)},r)},n.unbind=function(t,n,e,i){s.unbind(t,n,e,i)}},689:function(t,n,e){function i(t,n,e){for(e=e||document.documentElement;t&&t!==e;){if(s(t,n))return t;t=t.parentNode}return s(t,n)?t:null}var s=e(690);t.exports=i},690:function(t,n,e){function i(t,n){if(!t||1!==t.nodeType)return!1;if(r)return r.call(t,n);for(var e=s.all(n,t.parentNode),i=0;i<e.length;++i)if(e[i]===t)return!0;return!1}var s=e(691),o=window.Element.prototype,r=o.matches||o.webkitMatchesSelector||o.mozMatchesSelector||o.msMatchesSelector||o.oMatchesSelector;t.exports=i},691:function(t,n){function e(t,n){return n.querySelector(t)}n=t.exports=function(t,n){return n=n||document,e(t,n)},n.all=function(t,n){return n=n||document,n.querySelectorAll(t)},n.engine=function(t){if(!t.one)throw new Error(".one callback required");if(!t.all)throw new Error(".all callback required");return n.all=t.all,n}},692:function(t,n,e){"use strict";var i=function(){var t=this,n=t.$createElement,e=t._self._c||n;return e("div",{staticClass:"vux-range-input-box",staticStyle:{position:"relative","margin-right":"30px","margin-left":"50px"}},[e("input",{directives:[{name:"model",rawName:"v-model.number",value:t.currentValue,expression:"currentValue",modifiers:{number:!0}}],staticClass:"vux-range-input",domProps:{value:t.currentValue},on:{input:function(n){n.target.composing||(t.currentValue=t._n(n.target.value))},blur:function(n){t.$forceUpdate()}}})])},s=[],o={render:i,staticRenderFns:s};n.a=o}});