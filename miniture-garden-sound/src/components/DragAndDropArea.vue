<template>
  <div>
  </div> 
</template>

<script>

export default {
  data() {
    return {}
  },
  methods: {
    onDrop(event) {
      this.$emit('enableOverlay')
      let fileList = event.dataTransfer.files
      if (fileList.length == 0) {
        this.$emit('disableOverlay')
        return false
      }
      let files = []
      for (let i = 0; i < fileList.length; i++) {
        files.push(fileList[i])
      }
      let file = files.length > 0 ? files[0] : []
      if (file.type != 'audio/wav') {
        this.$emit('disableOverlay')
        return false
      }
      var reader = new FileReader()
      var parent = this
      reader.onload = function() {
        var source = this.result
        var bytes = new Uint8Array(source)
        var len = source.byteLength
        var byteString = ""
        for (var i = 0; i < len; i++) {
          byteString += String.fromCharCode(bytes[i])
        }
        var base64String = window.btoa(byteString)
        parent.$emit('unitySendMessage', base64String)
      }
      reader.readAsArrayBuffer(file)
    }
  }
}
</script>
