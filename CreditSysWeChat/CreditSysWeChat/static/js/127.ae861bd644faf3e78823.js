webpackJsonp([127],{1307:function(n,e,t){"use strict";var i=t(774),l=t(60);e.a={components:{Group:l.a,Selector:i.a},data:function(){return{demo01:"",demo02:"",defaultValue:"",plainList:["广东","广西"],list:[{key:"gd",value:"广东"},{key:"gx",value:"广西"}],list2:[{key:!0,value:"是"},{key:!1,value:"否"}],value1:"广西",value2:"gd",value3:!0,list1:["A","B","C"]}},methods:{onChange:function(n){console.log(n)}}}},1308:function(n,e,t){"use strict";var i=function(){var n=this,e=n.$createElement,t=n._self._c||e;return t("div",[t("group",{attrs:{title:"no placeholder, the current value is : "+n.defaultValue}},[t("selector",{attrs:{title:"省份",options:n.list},model:{value:n.defaultValue,callback:function(e){n.defaultValue=e},expression:"defaultValue"}})],1),n._v(" "),t("group",{attrs:{title:"with placeholder"}},[t("selector",{attrs:{placeholder:"请选择省份",title:"省份",name:"district",options:n.list},on:{"on-change":n.onChange},model:{value:n.demo01,callback:function(e){n.demo01=e},expression:"demo01"}})],1),n._v(" "),t("group",{attrs:{title:"without title"}},[t("selector",{attrs:{placeholder:"请选择省份",options:n.list},model:{value:n.demo02,callback:function(e){n.demo02=e},expression:"demo02"}})],1),n._v(" "),t("group",{attrs:{title:"set value=广西"}},[t("selector",{attrs:{title:"省份",options:n.plainList},on:{"on-change":n.onChange},model:{value:n.value1,callback:function(e){n.value1=e},expression:"value1"}})],1),n._v(" "),t("group",{attrs:{title:"readonly, displays just like a cell"}},[t("selector",{attrs:{value:"gd",readonly:"",title:"省份",options:n.list}})],1),n._v(" "),t("group",{attrs:{title:"use plain options"}},[t("selector",{attrs:{value:"C",title:"Selector",options:n.list1},on:{"on-change":n.onChange}})],1),n._v(" "),t("group",{attrs:{title:"multi selector"}},[t("selector",{attrs:{placeholder:"请选择省份",title:"省份",options:n.list}}),n._v(" "),t("selector",{attrs:{title:"省份",options:n.list},model:{value:n.value2,callback:function(e){n.value2=e},expression:"value2"}})],1),n._v(" "),t("group",{attrs:{title:"boolean selector: "+n.value3}},[t("selector",{attrs:{title:"Vux Is Cool",options:n.list2},model:{value:n.value3,callback:function(e){n.value3=e},expression:"value3"}})],1)],1)},l=[],o={render:i,staticRenderFns:l};e.a=o},318:function(n,e,t){"use strict";Object.defineProperty(e,"__esModule",{value:!0});var i=t(1307),l=t(1308),o=t(0),r=o(i.a,l.a,null,null,null);e.default=r.exports},452:function(n,e,t){"use strict";function i(n,e,t){if("function"==typeof Array.prototype.find)return n.find(e,t);t=t||this;var i,l=n.length;if("function"!=typeof e)throw new TypeError(e+" is not a function");for(i=0;i<l;i++)if(e.call(t,n[i],i,n))return n[i]}n.exports=i},520:function(n,e,t){"use strict";e.a={created:function(){this.uuid=Math.random().toString(36).substring(3,8)}}},774:function(n,e,t){"use strict";function i(n){t(775)}var l=t(777),o=t(778),r=t(0),a=i,s=r(l.a,o.a,a,null,null);e.a=s.exports},775:function(n,e,t){var i=t(776);"string"==typeof i&&(i=[[n.i,i,""]]),i.locals&&(n.exports=i.locals);t(227)("39358f0c",i,!0)},776:function(n,e,t){e=n.exports=t(226)(),e.push([n.i,'/**\n* actionsheet\n*/\n/**\n* datetime\n*/\n/**\n* tabbar\n*/\n/**\n* tab\n*/\n/**\n* dialog\n*/\n/**\n* x-number\n*/\n/**\n* checkbox\n*/\n/**\n* check-icon\n*/\n/**\n* Cell\n*/\n/**\n* Mask\n*/\n/**\n* Range\n*/\n/**\n* Tabbar\n*/\n/**\n* Header\n*/\n/**\n* Timeline\n*/\n/**\n* Switch\n*/\n/**\n* Button\n*/\n/**\n* swipeout\n*/\n/**\n* Cell\n*/\n/**\n* Badge\n*/\n/**\n* Popover\n*/\n/**\n* Button tab\n*/\n/* alias */\n/**\n* Swiper\n*/\n/**\n* checklist\n*/\n/**\n* popup-picker\n*/\n/**\n* popup\n*/\n/**\n* popup-header\n*/\n/**\n* form-preview\n*/\n/**\n* load-more\n*/\n/**\n* sticky\n*/\n/**\n* group\n*/\n/**\n* toast\n*/\n/**\n* icon\n*/\n/**\n* calendar\n*/\n/**\n* search\n*/\n/**\n* radio\n*/\n.weui-cell_access {\n  -webkit-tap-highlight-color: rgba(0, 0, 0, 0);\n  color: inherit;\n}\n.weui-cell_access:active {\n  background-color: #ECECEC;\n}\n.weui-cell_access .weui-cell__ft {\n  padding-right: 13px;\n  position: relative;\n}\n.weui-cell_access .weui-cell__ft:after {\n  content: " ";\n  display: inline-block;\n  height: 6px;\n  width: 6px;\n  border-width: 2px 2px 0 0;\n  border-color: #C8C8CD;\n  border-style: solid;\n  -webkit-transform: matrix(0.71, 0.71, -0.71, 0.71, 0, 0);\n          transform: matrix(0.71, 0.71, -0.71, 0.71, 0, 0);\n  position: relative;\n  top: -2px;\n  position: absolute;\n  top: 50%;\n  margin-top: -4px;\n  right: 2px;\n}\n.weui-cell_link {\n  color: #586C94;\n  font-size: 14px;\n}\n.weui-cell_link:first-child:before {\n  display: block;\n}\n.weui-cell_access.vux-cell-box {\n  padding-right: 13px;\n  position: relative;\n}\n.weui-cell_access.vux-cell-box:after {\n  content: " ";\n  display: inline-block;\n  height: 6px;\n  width: 6px;\n  border-width: 2px 2px 0 0;\n  border-color: #C8C8CD;\n  border-style: solid;\n  -webkit-transform: matrix(0.71, 0.71, -0.71, 0.71, 0, 0);\n          transform: matrix(0.71, 0.71, -0.71, 0.71, 0, 0);\n  position: relative;\n  top: -2px;\n  position: absolute;\n  top: 50%;\n  margin-top: -4px;\n  right: 17px;\n}\n.weui-cells {\n  margin-top: 1.17647059em;\n  background-color: #FFFFFF;\n  line-height: 1.41176471;\n  font-size: 17px;\n  overflow: hidden;\n  position: relative;\n}\n.weui-cells:before {\n  content: " ";\n  position: absolute;\n  left: 0;\n  top: 0;\n  right: 0;\n  height: 1px;\n  border-top: 1px solid #D9D9D9;\n  color: #D9D9D9;\n  -webkit-transform-origin: 0 0;\n          transform-origin: 0 0;\n  -webkit-transform: scaleY(0.5);\n          transform: scaleY(0.5);\n}\n.weui-cells:after {\n  content: " ";\n  position: absolute;\n  left: 0;\n  bottom: 0;\n  right: 0;\n  height: 1px;\n  border-bottom: 1px solid #D9D9D9;\n  color: #D9D9D9;\n  -webkit-transform-origin: 0 100%;\n          transform-origin: 0 100%;\n  -webkit-transform: scaleY(0.5);\n          transform: scaleY(0.5);\n}\n.weui-cells__title {\n  margin-top: 0.77em;\n  margin-bottom: 0.3em;\n  padding-left: 15px;\n  padding-right: 15px;\n  color: #999999;\n  font-size: 14px;\n}\n.weui-cells__title + .weui-cells {\n  margin-top: 0;\n}\n.weui-cells__tips {\n  margin-top: .3em;\n  color: #999999;\n  padding-left: 15px;\n  padding-right: 15px;\n  font-size: 14px;\n}\n.weui-cell {\n  padding: 10px 15px;\n  position: relative;\n  display: -webkit-box;\n  display: -webkit-flex;\n  display: flex;\n  -webkit-box-align: center;\n  -webkit-align-items: center;\n          align-items: center;\n}\n.weui-cell:before {\n  content: " ";\n  position: absolute;\n  left: 0;\n  top: 0;\n  right: 0;\n  height: 1px;\n  border-top: 1px solid #D9D9D9;\n  color: #D9D9D9;\n  -webkit-transform-origin: 0 0;\n          transform-origin: 0 0;\n  -webkit-transform: scaleY(0.5);\n          transform: scaleY(0.5);\n  left: 15px;\n}\n.weui-cell:first-child:before {\n  display: none;\n}\n.weui-cell_primary {\n  -webkit-box-align: start;\n  -webkit-align-items: flex-start;\n          align-items: flex-start;\n}\n.weui-cell__bd {\n  -webkit-box-flex: 1;\n  -webkit-flex: 1;\n          flex: 1;\n}\n.weui-cell__ft {\n  text-align: right;\n  color: #999999;\n}\n.vux-cell-justify {\n  height: 1.41176471em;\n}\n.vux-cell-justify.vux-cell-justify:after {\n  content: ".";\n  display: inline-block;\n  width: 100%;\n  overflow: hidden;\n  height: 0;\n}\n.weui-label {\n  display: block;\n  width: 105px;\n  word-wrap: break-word;\n  word-break: break-all;\n}\n.weui-input {\n  width: 100%;\n  border: 0;\n  outline: 0;\n  -webkit-appearance: none;\n  background-color: transparent;\n  font-size: inherit;\n  color: inherit;\n  height: 1.41176471em;\n  line-height: 1.41176471;\n}\n.weui-input::-webkit-outer-spin-button,\n.weui-input::-webkit-inner-spin-button {\n  -webkit-appearance: none;\n  margin: 0;\n}\n.weui-textarea {\n  display: block;\n  border: 0;\n  resize: none;\n  width: 100%;\n  color: inherit;\n  font-size: 1em;\n  line-height: inherit;\n  outline: 0;\n}\n.weui-textarea-counter {\n  color: #B2B2B2;\n  text-align: right;\n}\n.weui-cell_warn .weui-textarea-counter {\n  color: #E64340;\n}\n.weui-toptips {\n  display: none;\n  position: fixed;\n  -webkit-transform: translateZ(0);\n          transform: translateZ(0);\n  top: 0;\n  left: 0;\n  right: 0;\n  padding: 5px;\n  font-size: 14px;\n  text-align: center;\n  color: #FFF;\n  z-index: 5000;\n  word-wrap: break-word;\n  word-break: break-all;\n}\n.weui-toptips_warn {\n  background-color: #E64340;\n}\n.weui-cells_form .weui-cell__ft {\n  font-size: 0;\n}\n.weui-cells_form .weui-icon-warn {\n  display: none;\n}\n.weui-cells_form input,\n.weui-cells_form textarea,\n.weui-cells_form label[for] {\n  -webkit-tap-highlight-color: rgba(0, 0, 0, 0);\n}\n.weui-cell_warn {\n  color: #E64340;\n}\n.weui-cell_warn .weui-icon-warn {\n  display: inline-block;\n}\n.weui-cell_select {\n  padding: 0;\n}\n.weui-cell_select .weui-select {\n  padding-right: 30px;\n}\n.weui-cell_select .weui-cell__bd:after {\n  content: " ";\n  display: inline-block;\n  height: 6px;\n  width: 6px;\n  border-width: 2px 2px 0 0;\n  border-color: #C8C8CD;\n  border-style: solid;\n  -webkit-transform: matrix(0.71, 0.71, -0.71, 0.71, 0, 0);\n          transform: matrix(0.71, 0.71, -0.71, 0.71, 0, 0);\n  position: relative;\n  top: -2px;\n  position: absolute;\n  top: 50%;\n  right: 15px;\n  margin-top: -4px;\n}\n.weui-select {\n  -webkit-appearance: none;\n  border: 0;\n  outline: 0;\n  background-color: transparent;\n  width: 100%;\n  font-size: inherit;\n  height: 44px;\n  line-height: 44px;\n  position: relative;\n  z-index: 1;\n  padding-left: 15px;\n}\n.weui-cell_select-before {\n  padding-right: 15px;\n}\n.weui-cell_select-before .weui-select {\n  width: 105px;\n  box-sizing: border-box;\n}\n.weui-cell_select-before .weui-cell__hd {\n  position: relative;\n}\n.weui-cell_select-before .weui-cell__hd:after {\n  content: " ";\n  position: absolute;\n  right: 0;\n  top: 0;\n  width: 1px;\n  bottom: 0;\n  border-right: 1px solid #D9D9D9;\n  color: #D9D9D9;\n  -webkit-transform-origin: 100% 0;\n          transform-origin: 100% 0;\n  -webkit-transform: scaleX(0.5);\n          transform: scaleX(0.5);\n}\n.weui-cell_select-before .weui-cell__hd:before {\n  content: " ";\n  display: inline-block;\n  height: 6px;\n  width: 6px;\n  border-width: 2px 2px 0 0;\n  border-color: #C8C8CD;\n  border-style: solid;\n  -webkit-transform: matrix(0.71, 0.71, -0.71, 0.71, 0, 0);\n          transform: matrix(0.71, 0.71, -0.71, 0.71, 0, 0);\n  position: relative;\n  top: -2px;\n  position: absolute;\n  top: 50%;\n  right: 15px;\n  margin-top: -4px;\n}\n.weui-cell_select-before .weui-cell__bd {\n  padding-left: 15px;\n}\n.weui-cell_select-before .weui-cell__bd:after {\n  display: none;\n}\n.weui-cell_select-after {\n  padding-left: 15px;\n}\n.weui-cell_select-after .weui-select {\n  padding-left: 0;\n}\n.vux-selector-no-padding {\n  padding-left: 0;\n}\n.vux-selector.weui-cell_select {\n  padding: 0;\n}\n.vux-selector.weui-cell_select-after {\n  padding-left: 15px;\n}\n.vux-selector-readonly {\n  width: 100%;\n}\n',""])},777:function(n,e,t){"use strict";var i=t(8),l=t.n(i),o=t(452),r=t.n(o),a=t(520),s=function(n,e){var t=r()(e,function(e){return e.key===n});return t?t.value:n};e.a={name:"selector",mixins:[a.a],created:function(){void 0!==this.value&&(this.currentValue=this.value)},computed:{fixIos:function(){return!this.placeholder&&l()("undefined"===this.value||""===this.value)&&this.isIOS&&this.title},color:function(){return this.showPlaceholder?"#A9A9A9":""},processOptions:function(){return this.options.length&&{}.hasOwnProperty.call(this.options[0],"key")?this.options:this.options.map(function(n){return{key:n,value:n}})},showPlaceholder:function(){return!(void 0!==this.value&&""!==this.value||!this.placeholder)},labelClass:function(){return{"vux-cell-justify":"justify"===this.$parent.labelAlign||"justify"===this.$parent.$parent.labelAlign}}},filters:{findByKey:s},watch:{value:function(n){this.currentValue=n},currentValue:function(n){this.$emit("input",n),this.$emit("on-change",n)}},props:{title:String,direction:String,options:{type:Array,required:!0},name:String,placeholder:String,readonly:Boolean,value:[Boolean,String,Number,Object]},data:function(){return{currentValue:"",isIOS:/iPad|iPhone|iPod/.test(window.navigator.userAgent)}}}},778:function(n,e,t){"use strict";var i=function(){var n=this,e=n.$createElement,t=n._self._c||e;return t("div",{staticClass:"vux-selector weui-cell",class:{"weui-cell_select":!n.readonly,"weui-cell_select-after":n.title}},[n.title?t("div",{staticClass:"weui-cell__hd"},[t("label",{staticClass:"weui-label",class:n.labelClass,style:{width:n.$parent.labelWidth,textAlign:n.$parent.labelAlign,marginRight:n.$parent.labelMarginRight},attrs:{for:"vux-selector-"+n.uuid}},[n._v(n._s(n.title))])]):n._e(),n._v(" "),n.readonly?t("div",{staticClass:"weui-cell__ft vux-selector-readonly"},[n._v("\n    "+n._s(n._f("findByKey")(n.value,n.processOptions))+"\n  ")]):t("div",{staticClass:"weui-cell__bd"},[t("select",{directives:[{name:"model",rawName:"v-model",value:n.currentValue,expression:"currentValue"}],staticClass:"weui-select",staticStyle:{color:"red"},style:{direction:n.direction,color:n.color},attrs:{id:"vux-selector-"+n.uuid,ddd:n.color,name:n.name},on:{change:function(e){var t=Array.prototype.filter.call(e.target.options,function(n){return n.selected}).map(function(n){return"_value"in n?n._value:n.value});n.currentValue=e.target.multiple?t:t[0]}}},[n.showPlaceholder?t("option",{attrs:{value:""},domProps:{selected:void 0===n.value&&n.placeholder}},[n._v(n._s(n.placeholder))]):n._e(),n._v(" "),n.fixIos?t("option",{attrs:{disabled:""}}):n._e(),n._v(" "),n._l(n.processOptions,function(e){return t("option",{domProps:{value:e.key}},[n._v(n._s(e.value))])})],2)])])},l=[],o={render:i,staticRenderFns:l};e.a=o}});