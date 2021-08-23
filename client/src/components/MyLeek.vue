<template>
  <div>
    <h1>Hello World!</h1>
    <p>I am leek</p>
    <p>{{ myVal }} {{gameRules}}</p>
    <p>You can call me {{ myName + '(or am I?)' }}!</p>
    <p>{{ myMethod() }}</p>

    <ul>
      <li 
        v-for="(tile, index) in tiles"
        :key="tile"
      >
        My Tile: {{ tile }}
        <span v-if="index == playerPosition">(I am here)</span>
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  data: () => ({
    myVal: 42,
    myName: "not potato, i am leek",
    gameRules: "there ARE no rules",
    tiles: [1, 2, 3, 4, 5, 6, 123, 232],
    playerPosition: 4,
  }),

  methods: {
    someOtherMethod () {
      return this.myMethod()
    },
    myMethod () {
      return 'something here'
    }
  }
}
</script>

<style scoped>
</style>