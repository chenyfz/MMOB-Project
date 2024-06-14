<script setup lang="ts">

</script>

<template>
  <p class="title">
    Player Character
  </p>

  <p>
    You will play as this robot:
    <img src="/img-1.png" width="50">.
    The robot will be jumping automatically and continuously.
  </p>
  <p class="title">
    Game goal
  </p>

  <p>
    Ascend to the finish platform
    <img src="/img-2.png">
    by controlling and guiding the robot to jump across different types of platforms as efficiently and fast as possible. Try not to fall down off the screen to minimize the number of "deaths".
  </p>
  <p class="title">
    Controls
  </p>

  <p>
    Tilt your mobile phone to the left or right (over its y-axis or z-axis), to move the robot in the desired direction.
  </p>
  <p class="title">
    Platforms
  </p>

  <div class="platforms">
    <p>Normal: Static platform on which you can jump endlessly.</p>
    <div class="image-container"><img src="/img-3.png"></div>
    <div class="spacer" />
    <p>Breakable: Static platform on which you can only jump once before it disappears</p>
    <div class="image-container"><img src="/img-4.png"></div>
    <div class="spacer" />
    <p>Movable: Platform that moves horizontally and on which you can jump endlessly.</p>
    <div class="image-container"><img src="/img-5.png"></div>
  </div>

  <p class="title">
    Game versions
  </p>

  <p>• Control version; Without additional visual feedback on the tilt degree.</p>
  <p>• Balance bar; On top of the screen, a balance bar will be visualized to indicate the tilt degree of your mobile phone in real-time.</p>
  <div class="image-container">
    <img src="/img-6.png">
  </div>
  <p>• Power bars; Two power bars are visualized on the robot. The left bar (fill colour: red) indicates the level of tilt degree to the left, while the right bar (fill colour: blue) indicates the level of tilt degree to the right.</p>
  <p><img src="/img-7.png" width="48">: Tilt a lot to the left.</p>
  <p> <img src="/img-8.png" width="48">: Tilt slightly to the right.</p>
  <p class="title">
    Additional features
  </p>

  <p>• Screen wrap; If you move the robot out of the screen on the left or right edge, the robot gets teleported to the other side of the screen.  </p>
  <p>• Difficulty; The game is divided into seemingly transisioning stages, where each stage gradually increases the difficulty to add an extra challenge to the gameplay.  </p>
  <p>• Infinite lives; When you die by falling down off the screen, you will get respawned at start of section you died in.  </p>
</template>

<style scoped lang="stylus">
p
  margin-top: 4px
  font-size 15px

.title
  margin-top: 16px
  font-weight bold
  text-decoration: underline

.last-p
  border-top: 1px solid
  margin-top: 12px
  padding-top: 12px

img
  max-width calc(100vw - 48px)

.image-container {
  margin: 8px 16px
  display flex
  align-items center
  justify-content center
}
</style>