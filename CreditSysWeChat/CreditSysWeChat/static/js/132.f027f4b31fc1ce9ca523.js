webpackJsonp([132],{1513:function(n,e,t){"use strict";var a=t(1514);e.a={components:{Agree:a.a},data:function(){return{valueTrue:!0}}}},1514:function(n,e,t){"use strict";function a(n){t(1515)}var r=t(1517),i=t(1518),o=t(0),c=a,u=o(r.a,i.a,c,null,null);e.a=u.exports},1515:function(n,e,t){var a=t(1516);"string"==typeof a&&(a=[[n.i,a,""]]),a.locals&&(n.exports=a.locals);t(227)("f3076f80",a,!0)},1516:function(n,e,t){e=n.exports=t(226)(),e.push([n.i,'/**\n* actionsheet\n*/\n/**\n* datetime\n*/\n/**\n* tabbar\n*/\n/**\n* tab\n*/\n/**\n* dialog\n*/\n/**\n* x-number\n*/\n/**\n* checkbox\n*/\n/**\n* check-icon\n*/\n/**\n* Cell\n*/\n/**\n* Mask\n*/\n/**\n* Range\n*/\n/**\n* Tabbar\n*/\n/**\n* Header\n*/\n/**\n* Timeline\n*/\n/**\n* Switch\n*/\n/**\n* Button\n*/\n/**\n* swipeout\n*/\n/**\n* Cell\n*/\n/**\n* Badge\n*/\n/**\n* Popover\n*/\n/**\n* Button tab\n*/\n/* alias */\n/**\n* Swiper\n*/\n/**\n* checklist\n*/\n/**\n* popup-picker\n*/\n/**\n* popup\n*/\n/**\n* popup-header\n*/\n/**\n* form-preview\n*/\n/**\n* load-more\n*/\n/**\n* sticky\n*/\n/**\n* group\n*/\n/**\n* toast\n*/\n/**\n* icon\n*/\n/**\n* calendar\n*/\n/**\n* search\n*/\n/**\n* radio\n*/\n.weui-agree {\n  display: block;\n  padding: .5em 15px;\n  font-size: 13px;\n}\n.weui-agree a {\n  color: #586C94;\n}\n.weui-agree__text {\n  color: #999999;\n}\n.weui-agree__checkbox {\n  -webkit-appearance: none;\n          appearance: none;\n  outline: 0;\n  font-size: 0;\n  border: 1px solid #D1D1D1;\n  background-color: #FFFFFF;\n  border-radius: 3px;\n  width: 13px;\n  height: 13px;\n  position: relative;\n  vertical-align: 0;\n  top: 2px;\n}\n.weui-agree__checkbox:checked:before {\n  font-family: "weui";\n  font-style: normal;\n  font-weight: normal;\n  font-variant: normal;\n  text-transform: none;\n  text-align: center;\n  speak: none;\n  display: inline-block;\n  vertical-align: middle;\n  text-decoration: inherit;\n  content: "\\EA08";\n  color: #09BB07;\n  font-size: 13px;\n  position: absolute;\n  top: 50%;\n  left: 50%;\n  -webkit-transform: translate(-50%, -48%) scale(0.73);\n          transform: translate(-50%, -48%) scale(0.73);\n}\n.weui-agree__checkbox:disabled {\n  background-color: #E1E1E1;\n}\n.weui-agree__checkbox:disabled:before {\n  color: #ADADAD;\n}\n',""])},1517:function(n,e,t){"use strict";var a=t(520);e.a={name:"agree",mixins:[a.a],props:{value:Boolean},created:function(){this.currentValue=this.value},data:function(){return{currentValue:!1}},watch:{value:function(n){this.currentValue=n},currentValue:function(n){this.$emit("input",n)}}}},1518:function(n,e,t){"use strict";var a=function(){var n=this,e=n.$createElement,t=n._self._c||e;return t("label",{staticClass:"weui-agree",attrs:{for:"vux-agree-"+n.uuid}},[t("input",{directives:[{name:"model",rawName:"v-model",value:n.currentValue,expression:"currentValue"}],staticClass:"weui-agree__checkbox",attrs:{id:"vux-agree-"+n.uuid,type:"checkbox"},domProps:{checked:Array.isArray(n.currentValue)?n._i(n.currentValue,null)>-1:n.currentValue},on:{__c:function(e){var t=n.currentValue,a=e.target,r=!!a.checked;if(Array.isArray(t)){var i=n._i(t,null);r?i<0&&(n.currentValue=t.concat(null)):i>-1&&(n.currentValue=t.slice(0,i).concat(t.slice(i+1)))}else n.currentValue=r}}}),n._v(" "),t("span",{staticClass:"weui-agree__text"},[n._t("default")],2)])},r=[],i={render:a,staticRenderFns:r};e.a=i},1519:function(n,e,t){"use strict";var a=function(){var n=this,e=n.$createElement,t=n._self._c||e;return t("div",[t("agree",[n._v("阅读并同意"),t("a",{attrs:{href:"javascript:void(0);"}},[n._v("《相关条款》")])]),n._v(" "),t("agree",{model:{value:n.valueTrue,callback:function(e){n.valueTrue=e},expression:"valueTrue"}},[n._v("阅读并同意"),t("a",{attrs:{href:"javascript:void(0);"}},[n._v("《相关条款》")])])],1)},r=[],i={render:a,staticRenderFns:r};e.a=i},370:function(n,e,t){"use strict";Object.defineProperty(e,"__esModule",{value:!0});var a=t(1513),r=t(1519),i=t(0),o=i(a.a,r.a,null,null,null);e.default=o.exports},520:function(n,e,t){"use strict";e.a={created:function(){this.uuid=Math.random().toString(36).substring(3,8)}}}});