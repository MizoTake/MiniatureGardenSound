<template>
  <div id="screen">
    <div id="overlay" v-if="overlay" v-on:click.self="disableOverlay">
      <span class="description">Drag & Drop .wav file</span>
      <div id="content">
        <a :href="defaultMusic">
          <span class="defaultMusic">Default Music</span>
        </a>
        <a :href="github">
          <span class="github">GitHub</span>
        </a>
        <a :href="twitter">
          <span class="twitter">twitter</span>
        </a>
        <a :href="license">
          <span class="license">license</span>
        </a>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data: () => ({
    overlay: false,
    defaultMusic: "https://soundcloud.com/takeru-mizoguchi/nights-burnt",
    github: "https://github.com/MizoTake/MiniatureGardenSound",
    twitter: "https://twitter.com/OrangeGKeeper",
    license: ""
  }),
  methods: {
    enableOverlay: function() {
      this.overlay = true;
    },
    disableOverlay: function() {
      this.overlay = false;
      this.$emit("disableOverlay");
    }
  }
};
</script>

<style>
.screen * {
  border: 0;
  margin: 0;
  padding: 0;
}
.screen {
  position: absolute;
  top: 50%;
  left: 50%;
  -webkit-transform: translate(-50%, -50%);
  transform: translate(-50%, -50%);
  width: 100%;
  height: 100%;
  opacity: 0;
}

.description {
  position: absolute;
  top: 20%;
  left: 50%;
  -webkit-transform: translate(-50%, -50%);
  transform: translate(-50%, -50%);
  color: rgb(185, 183, 182);
  font-size: 24px;
}

.defaultMusic {
  position: absolute;
  top: 40%;
  left: 50%;
  -webkit-transform: translate(-50%, -50%);
  transform: translate(-50%, -50%);
  color: rgb(247, 168, 65);
  font-size: 24px;
}

.github {
  position: absolute;
  top: 50%;
  left: 50%;
  -webkit-transform: translate(-50%, -50%);
  transform: translate(-50%, -50%);
  color: rgb(0, 0, 0);
  font-size: 24px;
}

.twitter {
  position: absolute;
  top: 60%;
  left: 50%;
  -webkit-transform: translate(-50%, -50%);
  transform: translate(-50%, -50%);
  color: rgb(91, 204, 248);
  font-size: 24px;
}

.license {
  position: absolute;
  top: 70%;
  left: 50%;
  -webkit-transform: translate(-50%, -50%);
  transform: translate(-50%, -50%);
  color: rgb(237, 255, 227);
  font-size: 24px;
}

#overlay {
  z-index: 1;
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(109, 109, 109, 0.5);
  display: flex;
  align-items: center;
  justify-content: center;
}

#content {
  z-index: 2;
  width: 50%;
  padding: 1em;
  background: rgba(0, 0, 0, 0);
  display: flex;
  align-items: center;
  justify-content: center;
  color: coral;
}

</style>
