<template>
  <div id="app">
    <main
      id="main"
      @dragover.prevent="checkDrag($event, true)"
      @dragleave.prevent="checkDrag($event, false)"
      @drop.prevent="onDrop"
      v-on:click="onClick"
    >
      <unity
        class="webglContent"
        ref="unity"
        src="unitybuild/Build/unitybuild.json"
        v-bind:class="{ blurContent: overlay }"
        v-bind="{
          width: gameWidth,
          height: gameHeight,
          hideFooter: true,
          externalProgress: true,
          module: { TOTAL_STACK: 6 * 1024 * 1024 }
        }"
        unityLoader="unitybuild/Build/UnityLoader.js"
      ></unity>
      <dragAndDrop
        ref="dragAndDrop"
        v-on:unitySendMessage="unitySendMessage"
        v-on:disableOverlay="disableOverlay"
      ></dragAndDrop>
      <overlayMenu ref="overlayMenu" v-on:disableOverlay="disableOverlayFromOverlayMenu"></overlayMenu>
    </main>
  </div>
</template>

<script>
import unity from "vue-unity-webgl"
import overlayMenu from "./components/OverlayMenu.vue"
import dragAndDrop from "./components/DragAndDropArea.vue"

export default {
  name: "App",
  data: function() {
    return {
      gameWidth: window.innerWidth,
      gameHeight: window.innerHeight,
      overlay: false,
      overlayMenuDisable: false,
      unity: unity
    };
  },
  methods: {
    handleResize: function() {
      this.gameWidth = window.innerWidth
      this.gameHeight = window.innerHeight
    },
    onClick: function() {
      if (this.overlayMenuDisable) {
        this.overlayMenuDisable = false
        return
      }
      this.overlay = true
      this.$refs.overlayMenu.enableOverlay()
    },
    disableOverlay: function() {
      this.overlay = false
    },
    disableOverlayFromOverlayMenu: function() {
      this.overlay = false
      this.overlayMenuDisable = true
    },
    checkDrag(event, status) {
      this.overlay = status
    },
    onDrop(event) {
      this.overlay = true;
      this.$refs.dragAndDrop.onDrop(event)
    },
    unitySendMessage: function(byteString) {
      var splitLength = 1000
      var len = parseInt(byteString.length / splitLength)
      this.$refs.unity.message("NativeProvider", "MusicLength", len + 1)
      for (var i = 0; i < len; i++) {
        var next = byteString.substr(i * splitLength, splitLength)
        this.$refs.unity.message("NativeProvider", "DropMusic", next)
      }
      var last = byteString.substr(
        splitLength * len,
        byteString.length % splitLength
      )
      this.$refs.unity.message("NativeProvider", "DropMusic", last)
      this.overlay = false
    }
  },
  mounted: function() {
    window.addEventListener("resize", this.handleResize)
  },
  beforeDestroy: function() {
    window.removeEventListener("resize", this.handleResize)
  },
  components: { unity, overlayMenu, dragAndDrop }
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#main {
  z-index: 0;
}

.blurContent {
  filter: blur(10px);
}

.webglContent * {
  border: 0;
  margin: 0;
  padding: 0;
}
.webglContent {
  position: absolute;
  top: 50%;
  left: 50%;
  -webkit-transform: translate(-50%, -50%);
  transform: translate(-50%, -50%);
}

.webglContent .logo,
.progress {
  position: absolute;
  left: 50%;
  top: 50%;
  -webkit-transform: translate(-50%, -50%);
  transform: translate(-50%, -50%);
}
.webglContent .logo {
  background: url("/unitybuild/TemplateData/progressLogo.Light.png") no-repeat
    center / contain;
  width: 154px;
  height: 130px;
}
.webglContent .progress {
  height: 18px;
  width: 141px;
  margin-top: 90px;
}
.webglContent .progress .empty {
  background: url("/unitybuild/TemplateData/progressEmpty.Light.png") no-repeat
    right / cover;
  float: right;
  width: 100%;
  height: 100%;
  display: inline-block;
}
.webglContent .progress .full {
  background: url("/unitybuild/TemplateData/progressFull.Light.png") no-repeat
    left / cover;
  float: left;
  width: 0%;
  height: 100%;
  display: inline-block;
}

.webglContent .logo.Dark {
  background-image: url("/unitybuild/TemplateData/progressLogo.Dark.png");
}
.webglContent .progress.Dark .empty {
  background-image: url("/unitybuild/TemplateData/progressEmpty.Dark.png");
}
.webglContent .progress.Dark .full {
  background-image: url("/unitybuild/TemplateData/progressFull.Dark.png");
}
</style>
