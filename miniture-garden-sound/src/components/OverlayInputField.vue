<template>
  <div id="screen">
    <div id="overlay" v-if="overlay" v-on:click.self="disableOverlay">
      <div id="content">
        <md-field>
          <label>SoundCloud URL</label>
          <md-input v-model="initValue" readonly> </md-input>
        </md-field>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data: () => ({
    overlay: false,
    initValue: 'https://soundcloud.com/takeru-mizoguchi/nights-burnt'
  }),
  methods: {
    enableOverlay: function() {
      this.overlay = true
    },
    disableOverlay: function() {
      this.overlay = false
      this.$emit('disableOverlay')
    }
  }
}
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
