webpackJsonp([0],{1240:function(e,n,t){"use strict";var i=t(800);n.a={components:{DemoList:i.a}}},1241:function(e,n,t){var i=t(1242);"string"==typeof i&&(i=[[e.i,i,""]]),i.locals&&(e.exports=i.locals);t(227)("3977dd31",i,!0)},1242:function(e,n,t){n=e.exports=t(226)(),n.push([e.i,"\n.cbox[data-v-42aa8269] {\n  text-align: center;\n}\n.cbox-inner[data-v-42aa8269] {\n  padding: 15px 0;\n  width: 100%;\n  height: 100%;\n}\n.demo-list-box[data-v-42aa8269] {\n  margin-bottom: 10px;\n  background-color: #fff;\n  width: 100%;\n  overflow: scroll;\n  -webkit-overflow-scrolling: touch;\n}\n",""])},1243:function(e,n,t){"use strict";function i(e){var n=e.toLowerCase().replace(/-(.)/g,function(e,n){return n.toUpperCase()});return n=n.replace(/_(.)/g,function(e,n){return n.toUpperCase()}),n.slice(0,1).toUpperCase()+n.slice(1)}var o=t(80),a=t.n(o),r=t(439),c=t(444),s=t(1244),x=t.n(s),l=t(44),m=t(800);n.a={name:"demoList",components:{DemoList:m.a,Flexbox:r.a,FlexboxItem:c.a},filters:{camelCase:i},activated:function(){document.querySelector("#demo_list_box").scrollTop=this.demoTop},methods:{go:function(e){this.$router.push("/component/"+e)},split:function(e){for(var n=[],t=Math.ceil(e.length/3);t>0;)n.push(e.slice(3*(t-1),3*t)),t--;n=n.reverse();var i=n[n.length-1],o=i.length;if(o<3)for(var a=0;a<3-o;a++)i.push({name:"----",icon:""});return n}},data:function(){return{height:window.innerHeight-46-53,components:this.split(x.a)}},computed:a()({},Object(l.c)({demoTop:function(e){return e.vux.demoScrollTop}}))}},1244:function(e,n){e.exports=[{name:"actionsheet",icon:"&#xe624;"},{name:"alert",icon:"&#xe603;"},{name:"badge",icon:"&#xe65b;",color:"#f74c31"},{name:"blur",icon:"&#xe640;"},{name:"button-tab",icon:"&#xe659;",items:["button-tab","button-tab-item"]},{name:"calendar",icon:"&#xe62b;"},{name:"card",icon:"&#xe658;"},{name:"cell-box",icon:"&#xe62a;"},{name:"cell-form-preview",icon:"&#xe62a;"},{name:"cell",icon:"&#xe62a;"},{name:"check-icon",icon:"&#xe619;"},{name:"checker",icon:"&#xe655;",items:["checker","checker-item"]},{name:"checklist",icon:"&#xe61d;"},{name:"clocker",icon:"&#xe620;"},{name:"color-picker",icon:"&#xe63f;",color:"#f2c400"},{name:"confirm",icon:"&#xe608;"},{name:"countdown",icon:"&#xe653;"},{name:"countup",icon:"&#xe63e;"},{name:"datetime-range",icon:"&#xe60a;"},{name:"datetime-view",icon:"&#xe60a;"},{name:"datetime",icon:"&#xe60a;"},{name:"divider",icon:"&#xe65d;"},{name:"drawer",icon:"&#xe62a;"},{name:"flexbox",icon:"&#xe61f;",items:["flexbox","flexbox-item"]},{name:"flow",icon:"&#xe656;",items:["flow","flow-state","flow-line"]},{name:"form-preview",icon:"&#xe699;"},{name:"grid",icon:"&#xe661;",items:["grid","grid-item"]},{name:"group",icon:"&#xe62a;"},{name:"icon",icon:"&#xe619;"},{name:"inline-calendar",icon:"&#xe62b;"},{name:"inline-loading",icon:"&#xe610;"},{name:"inline-x-number",icon:"&#xe605;"},{name:"load-more",icon:"&#xe610;"},{name:"loading",icon:"&#xe610;"},{name:"marquee",icon:"&#xe662;",items:["marquee","marquee-item"]},{name:"masker",icon:"&#xe651;"},{name:"msg",icon:"&#xe619;"},{name:"panel",icon:"&#xe658;"},{name:"picker",icon:"&#xe627;"},{name:"popover",icon:"&#xe65f;"},{name:"popup-header",icon:"&#xe654;"},{name:"popup-picker",icon:"&#xe626;"},{name:"popup-radio",icon:"&#xe60f;"},{name:"popup",icon:"&#xe61e;"},{name:"previewer",icon:"&#xe65c;"},{name:"qrcode",icon:"&#xe65a;"},{name:"radio",icon:"&#xe60f;"},{name:"range",icon:"&#xe60b;"},{name:"rater",icon:"&#xe606;",color:"#FF9900"},{name:"scroller",icon:"&#xe641;"},{name:"search",icon:"&#xe63b;"},{name:"selector",icon:"&#xe607;"},{name:"spinner",icon:"&#xe610;"},{name:"step",icon:"&#xe65e;",items:["step","step-item"]},{name:"sticky",icon:"&#xe623;"},{name:"swipeout",icon:"&#xe641;",items:["swipeout","swipeout-item","swipeout-button"]},{name:"swiper",icon:"&#xe612;"},{name:"tab",icon:"&#xe615;",items:["tab","tab-item"]},{name:"tabbar",icon:"&#xe657;",items:["tabbar","tabbar-item"]},{name:"timeline",icon:"&#xe656;"},{name:"toast",icon:"&#xe625;"},{name:"view-box",icon:"&#xe641;"},{name:"wechat-emotion",icon:"&#xe63c;"},{name:"x-address",icon:"&#xe61b;"},{name:"x-button",icon:"&#xe616;"},{name:"x-circle",icon:"&#xe63d;"},{name:"x-dialog",icon:"&#xe608;"},{name:"x-header",icon:"&#xe654;"},{name:"x-icon",icon:"&#xe619;"},{name:"x-img",icon:"&#xe602;"},{name:"x-input",icon:"&#xe614;"},{name:"x-number",icon:"&#xe605;"},{name:"x-progress",icon:"&#xe618;"},{name:"x-switch",icon:"&#xe61c;"},{name:"x-table",icon:"&#xe66d;"},{name:"x-textarea",icon:"&#xe611;"}]},1245:function(e,n,t){"use strict";var i=function(){var e=this,n=e.$createElement,t=e._self._c||n;return t("div",{staticClass:"demo-list-box",style:{height:e.height+"px"},attrs:{id:"demo_list_box"}},e._l(e.components,function(n,i){return t("flexbox",{key:i,attrs:{gutter:0}},e._l(n,function(n){return t("flexbox-item",{key:n.name,staticClass:"cbox vux-1px-t vux-tap-active",attrs:{span:1/3},nativeOn:{click:function(t){e.go(n.name.toLowerCase())}}},[t("div",{staticClass:"vux-1px-r cbox-inner"},[t("span",{staticClass:"demo-icon demo-icon-big",style:{color:n.color},domProps:{innerHTML:e._s(n.icon)}}),e._v(" "),t("br"),e._v(" "),t("span",{style:{fontSize:n.name.length>12?"12px":""}},[e._v(e._s(e._f("camelCase")(n.name)))])])])}))}))},o=[],a={render:i,staticRenderFns:o};n.a=a},1246:function(e,n,t){"use strict";var i=function(){var e=this,n=e.$createElement,t=e._self._c||n;return t("div",[t("keep-alive",[t("demo-list")],1)],1)},o=[],a={render:i,staticRenderFns:o};n.a=a},439:function(e,n,t){"use strict";function i(e){t(440)}var o=t(442),a=t(443),r=t(0),c=i,s=r(o.a,a.a,c,null,null);n.a=s.exports},440:function(e,n,t){var i=t(441);"string"==typeof i&&(i=[[e.i,i,""]]),i.locals&&(e.exports=i.locals);t(227)("7bc5f7ea",i,!0)},441:function(e,n,t){n=e.exports=t(226)(),n.push([e.i,"\n.vux-flexbox {\n  width: 100%;\n  text-align: left;\n  display: -webkit-box;\n  display: flex;\n  display: -webkit-flex;\n  box-align: center;\n  -webkit-box-align: center;\n  -webkit-align-items: center;\n          align-items: center;\n}\n.vux-flexbox .vux-flexbox-item {\n  -webkit-box-flex: 1;\n          flex: 1;\n  -webkit-flex: 1;\n  min-width: 20px;\n  width: 0%;\n}\n.vux-flexbox .vux-flexbox-item:first-child {\n  margin-left: 0!important;\n  margin-top: 0!important;\n}\n.vux-flex-col {\n  box-orient: vertical;\n  -webkit-box-orient: vertical;\n  -webkit-box-direction: normal;\n  -webkit-flex-direction: column;\n          flex-direction: column;\n}\n.vux-flex-col > .vux-flexbox-item {\n  width: 100%;\n}\n.vux-flex-row {\n  box-direction: row;\n  box-orient: horizontal;\n  -webkit-box-orient: horizontal;\n  -webkit-box-direction: normal;\n  -webkit-flex-direction: row;\n          flex-direction: row;\n}\n",""])},442:function(e,n,t){"use strict";n.a={name:"flexbox",props:{gutter:{type:Number,default:8},orient:{type:String,default:"horizontal"},justify:String,align:String,wrap:String,direction:String},computed:{styles:function(){return{"justify-content":this.justify,"-webkit-justify-content":this.justify,"align-items":this.align,"-webkit-align-items":this.align,"flex-wrap":this.wrap,"-webkit-flex-wrap":this.wrap,"flex-direction":this.direction,"-webkit-flex-direction":this.direction}}}}},443:function(e,n,t){"use strict";var i=function(){var e=this,n=e.$createElement;return(e._self._c||n)("div",{staticClass:"vux-flexbox",class:{"vux-flex-col":"vertical"===e.orient,"vux-flex-row":"horizontal"===e.orient},style:e.styles},[e._t("default")],2)},o=[],a={render:i,staticRenderFns:o};n.a=a},444:function(e,n,t){"use strict";var i=t(445),o=t(446),a=t(0),r=a(i.a,o.a,null,null,null);n.a=r.exports},445:function(e,n,t){"use strict";var i=["-moz-box-","-webkit-box-",""];n.a={name:"flexbox-item",props:{span:[Number,String],order:[Number,String]},beforeMount:function(){this.bodyWidth=document.documentElement.offsetWidth},methods:{buildWidth:function(e){return"number"==typeof e?e<1?e:e/12:"string"==typeof e?e.replace("px","")/this.bodyWidth:void 0}},computed:{style:function(){var e={};if(e["horizontal"===this.$parent.orient?"marginLeft":"marginTop"]=this.$parent.gutter+"px",this.span)for(var n=0;n<i.length;n++)e[i[n]+"flex"]="0 0 "+100*this.buildWidth(this.span)+"%";return void 0!==this.order&&(e.order=this.order),e}},data:function(){return{bodyWidth:0}}}},446:function(e,n,t){"use strict";var i=function(){var e=this,n=e.$createElement;return(e._self._c||n)("div",{staticClass:"vux-flexbox-item",style:e.style},[e._t("default")],2)},o=[],a={render:i,staticRenderFns:o};n.a=a},800:function(e,n,t){"use strict";function i(e){t(1241)}var o=t(1243),a=t(1245),r=t(0),c=i,s=r(o.a,a.a,c,"data-v-42aa8269",null);n.a=s.exports},87:function(e,n,t){"use strict";Object.defineProperty(n,"__esModule",{value:!0});var i=t(1240),o=t(1246),a=t(0),r=a(i.a,o.a,null,null,null);n.default=r.exports}});