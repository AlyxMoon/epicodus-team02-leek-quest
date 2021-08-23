<template>  
  <div 
    class="grid"
    :style="gridStyles"
  >
    <div 
      class="cell" 
      :class="{ active: isPlayerAtPosition(i - 1) }"
      v-for="i of (boardSize * boardSize)"
      :key="i"
      @click="handleCellClick(i - 1)"
    >
      <span class="position">
        {{ getRowFromIndex(i - 1)}},{{ getColFromIndex(i - 1) }}
      </span>
    </div>
  </div>
</template>

<script>
export default {
  name: 'GamePage',

  data: () => ({
    boardSize: 20,
    position: [0, 0],
  }),

  computed: {
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
        row === this.position[0] && 
        col === this.position[1]
      )
    },

    handleCellClick (index) {
      const row = this.getRowFromIndex(index)
      const col = this.getColFromIndex(index)

      this.position[0] = row
      this.position[1] = col
    }
  }
}
</script>

<style scoped>

.grid {
  --cell-size: 30px;
  --cells-per-row: 20;

  margin: 0 auto;
  max-width: fit-content;

  display: grid;
  grid-gap: 1px;
  grid-template-columns: repeat(var(--cells-per-row), var(--cell-size));
  grid-auto-rows: var(--cell-size);

  background-color: black;
  border: 1px solid black;
}

.cell {
  display: flex;
  justify-content: center;
  align-items: center;

  background-color: white;

  cursor: pointer;
  user-select: none;
}

.cell.active {
  background-color: grey;
}

.position {
  font-size: 0.7em;
}
</style>