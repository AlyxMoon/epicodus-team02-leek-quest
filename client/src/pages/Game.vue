<template>  
  <div 
    class="grid"
    :style="gridStyles"
  >
    <div 
      class="cell" 
      :class="{ 
        active: isPlayerAtPosition(i - 1),
        'has-other-players': getOtherPlayersAtPosition(i - 1).length > 0,
        'can-move-to': isNextToPlayerPosition(i - 1),
      }"
      v-for="i of (boardSize * boardSize)"
      :key="i"
      @click="handleCellClick(i - 1)"
    >
      <LeekIcon v-if="isPlayerAtPosition(i - 1)" />

      <template v-if="getOtherPlayersAtPosition(i - 1).length > 0">
        <LeekIcon />
      </template>
    </div>
  </div>

  <h3>User List</h3>
  <ol>
    <li
      v-for="user of userList"
      :key="user.id"
    >
      {{ user.userName }}
    </li>
  </ol>

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
      user: 'user',
      userList: 'userList',

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

  created () {
    this.getLeekList()
  },

  methods: {
    ...mapActions(['leekUserList', 'updateUserPosition']),

    async getLeekList () {
      await this.leekUserList()
    },

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

    getOtherPlayersAtPosition (index) {
      const row = this.getRowFromIndex(index)
      const col = this.getColFromIndex(index)

      return this.userList.filter(user => {
        return (
          user.id !== this.user.id &&
          user.positionX === col && user.positionY === row
        )
      })
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

.cell.has-other-players {
  background-color: #444;
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

html{
    background: radial-gradient(
    circle,
    rgba(124, 219, 116, 0.936) 31%,
    rgba(41, 210, 52, 0.8748541652989321) 100%
  );
}
</style>