<template>
    <div class="main" >
        <header>Главная страница</header>
        <div class="widgets" >
            <div class="widget_item " >
                <h2>Scoreboard</h2>
                <table>
                    <thead>
                    <tr>
                        <th>Номер позиции</th>
                        <th>Имя / никнэйм</th>
                        <th>Количество баллов</th>
                    </tr>
                    </thead>
                    <tbody>
                    <tr v-for="(player, index) in players" :key="index">
                        <td>{{ index + 1 }}</td>
                        <td>{{ player.name }}</td>
                        <td>{{ player.score }}</td>
                    </tr>
                    </tbody>
                </table>
            </div>

            <div class="widget_item list_events" >
                    
            </div>
            <div class="widget_item list_future-events" >
                    
            </div>
        </div>
    </div>
</template>

<script>
import { ref } from 'vue'

export default {
  setup() {
    const players = ref([
      { name: 'John', score: 100 },
      { name: 'Jane', score: 50 },
      { name: 'Bob', score: 25 },
    ])
    return { players }
  }
}
</script>