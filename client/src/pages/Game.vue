<template>  
  <div 
    class="grid"
    :style="gridStyles"
  >
    <div 
      class="cell" 
      :class="{ 
        active: isPlayerAtPosition(i - 1),
        'can-move-to': isNextToPlayerPosition(i - 1),
      }"
      v-for="i of (boardSize * boardSize)"
      :key="i"
      @click="handleCellClick(i - 1)"
    >
      <LeekIcon v-if="isPlayerAtPosition(i - 1)" />
    </div>
  </div>
</template>

<script>
import { mapActions, mapState } from 'vuex'
import LeekIcon from '../components/LeekIcon'

export default {
  name: 'GamePage',

  components: {
    LeekIcon,
  },

  data: () => ({
    boardSize: 20,
  }),

  computed: {
    ...mapState({
      position: ({ user }) => {
        if (!user) return [0, 0]
        return [user.positionX, user.positionY]
      }
    }),

    positionText () {
      const row = this.position[0]
      const col = this.position[1]
      return `You are at position ${row},${col}`
    },

    gridStyles () {
      return {
        '--cells-per-row': this.boardSize,
      }
    },
  },

  methods: {
    ...mapActions(['updateUserPosition']),

    getRowFromIndex (index) {
      return Math.floor(index / this.boardSize)
    },

    getColFromIndex (index) {
      return index % this.boardSize
    },

    isPlayerAtPosition (index) {
      const row = this.getRowFromIndex(index)
      const col = this.getColFromIndex(index)
      return (
        row === this.position[1] && 
        col === this.position[0]
      )
    },

    isNextToPlayerPosition (index) {
      const [x, y] = this.position

      const row = this.getRowFromIndex(index)
      const col = this.getColFromIndex(index)

      if (col === x && row === y) return false
      return (
        (col >= x - 1 && col <= x + 1) &&
        (row >= y - 1 && row <= y + 1)
      )
    },

    handleCellClick (index) {
      const row = this.getRowFromIndex(index)
      const col = this.getColFromIndex(index)

      if (!this.isNextToPlayerPosition(index)) return

      let direction = ''
      if (row === this.position[1] - 1) direction += 'Up'
      if (row === this.position[1] + 1) direction += 'Down'
      if (col === this.position[0] - 1) direction += 'Left'
      if (col === this.position[0] + 1) direction += 'Right'

      this.updateUserPosition(direction)
    }
  }
}
</script>

<style scoped>
.grid {
  --cell-size: 50px;
  --cells-per-row: 20;

  margin: 0 auto;
  max-width: fit-content;

  display: grid;
  grid-gap: 1px;
  grid-template-columns: repeat(var(--cells-per-row), var(--cell-size));
  grid-auto-rows: var(--cell-size);

  background-color: black;
  border: 1px solid black;
  overflow: auto;
}

.cell {
  display: flex;
  justify-content: center;
  align-items: center;

  background-color: white;

  cursor: default;
  user-select: none;
}

.cell.active {
  background-color: black;
}

.cell.can-move-to {
  background-color: #DDD;
  cursor: pointer;
}

.position {
  font-size: 0.7em;
}
</style>